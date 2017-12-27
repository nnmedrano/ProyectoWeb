using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Bathroom()
        {
            return View();
        }

        public ActionResult Bedroom()
        {
            return View();
        }

        public ActionResult Kitchen()
        {
            return View();
        }

        public ActionResult Living()
        {
            return View();
        }
    }
}