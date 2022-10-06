using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherTestProj.Models;

namespace WeatherTestProj.Controllers
{
    public class SubmitterController : Controller
    {
        //[HttpGet]
        // GET: Submit
        //public ActionResult ThisIsTheOne()
        //{
        //    return View("SearchPage");
        //}
        //public virtual ActionResult Save(MyViewModel model)
        //{
        //    model.Save();

        //---more code to do stuff here
        //}

        //[HttpPost]

        //public ViewResult Index()
        //{
            //Code to save the customer data here
        //    ViewData["error"] = "Customer Data Update successfully";
        //    return View();
        //}
        [HttpPost]
        public ActionResult FormSearch(Models.FormTest sm)
        {
            ViewBag.Terms = sm.SearchTerms;
            return View("Submitter");
        }
    }
}