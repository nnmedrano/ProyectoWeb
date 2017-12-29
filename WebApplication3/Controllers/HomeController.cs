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

        public ActionResult Login(string mail, Nullable<Int32> contraseña)
        {
            if(mail == null && contraseña == null)
                return View();

            Person person = db.People.Where(p => p.Mail == mail).Where(p2 => p2.Contraseña == contraseña).Select(p => p).FirstOrDefault();

            if (person != null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
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