using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datalayer;
namespace mycms.Controllers
{
    public class searchController : Controller
    {
        // GET: search
        private IPagerepository pr;
        mycmscontext db = new mycmscontext();
        public searchController()
        {
            pr = new pagerepository(db);
        }
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(pr.searchpage(q));
        }
    }
}