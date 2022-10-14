using WeatherTestProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherTestProj.Services.Business;

namespace WeatherTestProj.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(UserModel userModel)
        {
            //return "Results: Username = " + userModel.username + " PW: " + userModel.password;
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);
            if (success)
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure");
            }
        }
    }
}