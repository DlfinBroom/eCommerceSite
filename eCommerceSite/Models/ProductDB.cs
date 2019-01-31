using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public static class ProductDB {
        public static Product AddProduct(Product pro, CommerceContext context) {
            context.products.Add(pro);
            context.SaveChanges();

            return pro;
        }

        public static List<Product> GetProducts(CommerceContext context) {
            return context.products.ToList();
        }
    }
}
