using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is where you view your inventory summary.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This is where you purchase your product.";

            return View();
        }
    }
}