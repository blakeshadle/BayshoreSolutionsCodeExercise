using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BayshoreSolutions.Framework;

namespace BayshoreSolutions.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConvertNumber(decimal number)
        {
            NumberConverter nc = new NumberConverter(number);
            string output = nc.Convert();
            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}