using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerFactory.Controllers
{
    public class HomeController : Controller
    {
        private ILogger Logger;
        public HomeController():this(new DefaultLogger())
        {

        }
        public HomeController(ILogger logger)
        {
            Logger = logger;
        }
        // GET: Home
        public ActionResult Index()
        {
            Logger.Write("En el método de acción Index...");
            return Content("Bienvenidos!!!");
        }
    }
}