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

        public IActionResult Index() {
            List<Product> products = ProductDB.GetProducts(context);
            return View(products);
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
    }
}