using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using FirstWebbApp.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace FirstWebbApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(IDataBase dataBase, UserManager<Account> usermanager,
            SignInManager<Account> signInManager) : base(dataBase)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            ViewBag.returnurl = returnurl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = _userManager.FindByNameAsync(model.UserName).Result;
            if (user == null)
            {
                ModelState.AddModelError("LoginData", "username and password is wrong");
                return View(model);
            }

            var result = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;
            if (result.Succeeded == false)
            {
                ModelState.AddModelError("LoginData", "username and password is wrong");
                return View(model);
            }
            return Redirect(this.CreateUrl(returnurl));

        }

        [HttpGet]
        public IActionResult Register(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model, string returnurl)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var account = new Account
            {
                Email = model.Email,
                Number = model.PhoneNumber,
                UserName = model.Username
            };
            var result=_userManager.CreateAsync(account, model.Password).Result;
            if (result.Succeeded)
            { 
                _=_userManager.AddToRoleAsync(account, "Admin").Result;
              //_ = _userManager.AddToRoleAsync(account, "Admin").Result;
            }
            else
            {
                ModelState.AddModelError("RegisterData","Register failed");
                return View(model);
            }
            //_userManager.AddToRoleAsync(account, "Customer");
            return Redirect(this.CreateUrl(returnurl));
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        private string CreateUrl(string returnurl)
        {
            if (Url.IsLocalUrl(returnurl))
            {
                return returnurl;
            }

            return "/";
        }
    }
}
