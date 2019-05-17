using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstTimeDadSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstTimeDadSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly SiteContext _context;
        private readonly IHttpContextAccessor _accessor;

        public AccountController(SiteContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Member m)
        {
            if (ModelState.IsValid)
            {
                //Add to DB
                MemberDb.AddMember(m, _context);
                SessionHelper.LogUserIn(_accessor, m.MemberID);

                //Redirect to index page
                return RedirectToAction("Index", "Home");
            }
            //Returning the same View, with error messages
            return View(m);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Check if member exists
                Member member = (from m in _context.Members
                                 where m.Email == model.Email && m.Password == model.Password
                                 select m).SingleOrDefault();

                //log user in by creating a session
                if (member != null)
                {
                    //create session
                    SessionHelper.LogUserIn(_accessor, member.MemberID);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Tell users credential do not match a record
                    ModelState.AddModelError("", "Credentials not found");
                    return View(model);
                }
            }
            //return view with errors
            return View(model);
        }

        public IActionResult LogOut()
        {
            //Destroy Session (Log the use out)
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}