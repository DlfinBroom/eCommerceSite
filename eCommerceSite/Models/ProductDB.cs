using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public static class ProductDB {
        public static Product AddProduct(Product pro, CommerceContext context) {
            context.Products.Add(pro);
            context.SaveChanges();

            return pro;
        }

        public static List<Product> GetProducts(CommerceContext context) {
            return context.Products.ToList();
        }

        public static Product GetProduct(int id, CommerceContext context) {
            Product pro = (from p in context.Products
                           where p.ProductID == id
                           select p).Single();
            return pro;
        }

        public static List<Product> GetProductsByPage(int pageNum, int pageSize, CommerceContext context) {
            return context.Products
                .OrderBy(p => p.Name)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public static List<Product> SearchProducts(SearchCriteria criteria, CommerceContext context) {

            IQueryable<Product> allProducts = from p in context.Products select p;

            if (criteria.LowPrice.HasValue) {
                allProducts = from p in allProducts
                              where p.Price >= criteria.LowPrice
                              select p;
            }
            if (criteria.HighPrice.HasValue) {
                allProducts = from p in allProducts
                              where p.Price <= criteria.HighPrice
                              select p;
            }

        }


        /// <summary>
        /// Returns the total number of pages needed 
        /// to display all products given the page size
        /// </summary>
        public static int GetMaxPage(CommerceContext context, int pageSize) {
            int numProducts = (from p in context.Products
                               select p).Count();
            if( numProducts % pageSize != 0) {
                return 1 + (numProducts / pageSize);
            }
            else {
                return numProducts / pageSize;
            }
        }
    }
}
