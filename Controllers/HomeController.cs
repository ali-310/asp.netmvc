using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datalayer;

namespace mycms.Controllers
{
    public class HomeController : Controller
    {
        mycmscontext db = new mycmscontext();
        private IPagerepository pagerepository;
        public HomeController()
        {
            pagerepository = new pagerepository(db);
        }
        public ActionResult Index()
        {
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
        public ActionResult slider()
        {
            return PartialView(pagerepository.pagesinslider());
        }
    }
}