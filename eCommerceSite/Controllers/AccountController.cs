using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
                MemberDB.AddMember(mem, _context);
                HttpContext.Session.SetInt32("Id", m.MemberId);

                return RedirectToAction("Index", "Home");
            }
            return View(mem);
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                Member member = (from m in _context.members
                                 where m.Email == model.Email &&
                                       m.Password == model.Password
                                 select m).SingleOrDefault();

                if(member != null) {
                    HttpContext.Session.SetInt32("Id", member.MemberID);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("", "Credentials not found");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
