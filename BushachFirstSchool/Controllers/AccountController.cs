using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Infrastructure.Abstract;
using BushachFirstSchool.Filters;
using WebMatrix.WebData;
using System.Web.Security;

namespace BushachFirstSchool.Controllers
{
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public AccountController(IAuthProvider auth) 
        {
            _authprovider = auth;
        }

        public ActionResult Login()
        {
         /*  WebSecurity.CreateUserAndAccount("Admin", "admin15b10");
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            Roles.AddUserToRole("Admin", "Admin");*/

            return View();
        }
        [HttpPost]
        public ActionResult Login(String userName, String password, string returnUrl)
        {

            if (_authprovider.Authenticate(userName, password))
            {
                if (returnUrl == null)
                {
                    return   RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else 
            {
                TempData["LoginFail"] = true;
                return View();
            }

        }
        public ActionResult LogOut()
        {
            _authprovider.Logout();
            return RedirectToAction("Index", "Home");
        }
        private IAuthProvider _authprovider ;

    }
}
