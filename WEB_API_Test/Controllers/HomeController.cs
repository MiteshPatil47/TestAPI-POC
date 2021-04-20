using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_API_Test.Services;

namespace WEB_API_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SampleService service = new SampleService();
             service.PostAsync();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}