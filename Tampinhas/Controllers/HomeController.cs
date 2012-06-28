using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tampinhas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bem-vindo ao Tampinhas!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca do Tampinhas...";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Deixe a sua mensagem que entraremos em contacto consigo.";
            return View();
        }


    }
}
