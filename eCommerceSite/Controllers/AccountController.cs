using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers {
    public class AccountController : Controller {

        private readonly CommerceContext _context;

        public AccountController(CommerceContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Member mem) {
            if (ModelState.IsValid) {
                // Add to Db
                MemberDB.AddMember(mem, _context);

                // Redirect to index page
                return RedirectToAction("Index", "Home");
            }

            // Returning the save view with error msg
            return View(mem);
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }
    }
}
