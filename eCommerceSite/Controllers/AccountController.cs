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
        private readonly IHttpContextAccessor _accessor;

        public AccountController(CommerceContext context, IHttpContextAccessor accessor) {
            _context = context;
            _accessor = accessor;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Member mem) {
            if (ModelState.IsValid) {
                MemberDB.AddMember(mem, _context);
                SessionHelper.LogUserIn(mem.MemberId, _accessor);

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
                Member member = (from m in _context.Members
                                 where m.Email == model.Email &&
                                       m.Password == model.Password
                                 select m).SingleOrDefault();

                if(member != null) {
                    SessionHelper.LogUserIn(member.MemberId, _accessor);
                    HttpContext.Session.SetInt32("Id", member.MemberId);
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
