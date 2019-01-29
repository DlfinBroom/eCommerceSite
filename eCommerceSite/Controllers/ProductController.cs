using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers {
    public class ProductController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product pro) {
            if (ModelState.IsValid) {
                // Add to DB
                return View();
            }

            return View(pro);
        }
    }
}