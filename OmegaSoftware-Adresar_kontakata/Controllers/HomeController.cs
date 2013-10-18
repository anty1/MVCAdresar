using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmegaSoftware_Adresar_kontakata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Početna stranica adresara kontakata za tvrtku OmegaSoftware.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Upute za korištenje.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ante Šimić, mag. ing. IKT-a";
            return View();
        }
    }
}
