using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers {
    public class ProductController : Controller {

        private readonly CommerceContext context;

        public ProductController(CommerceContext dbContext) {
            context = dbContext;
        }

        // Id == Page#
        public IActionResult Index(int? id) {
            // List<Product> products = ProductDB.GetProducts(context);

            int pageNum = (id.HasValue) ? id.Value : 1;
            const int PageSize = 7;

            List<Product> Products = ProductDB.GetProductsByPage(pageNum, PageSize, context);
            int MaxPage = ProductDB.GetMaxPage(context, PageSize);
            int CurrPage = pageNum;

            var Pivm = new ProductIndexViewModel(Products, MaxPage, CurrPage);

            return View(Pivm);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product pro) {
            if (ModelState.IsValid) {
                ProductDB.AddProduct(pro, context);
                ViewData["Massage"] = pro.Name + " was added!";
                return View();
            }

            return View(pro);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Product pro = ProductDB.GetProduct(id, context);
            return View(pro);
        }
        [HttpPost]
        public IActionResult Edit(Product pro) {
            if (ModelState.IsValid) {
                context.Update(pro);
                context.SaveChanges();
                ViewData["Message"] = "Product Updated!";
            }
            return View(pro);
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            Product pro = ProductDB.GetProduct(id, context);
            return View(pro);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id) {
            Product pro = ProductDB.GetProduct(id, context);
            context.Products.Remove(pro);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search(SearchCriteria search) {
            search.Products = ProductDB.SearchProducts(search, context);

            return View(search);
        }
    }
}