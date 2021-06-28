using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using datalayer;

namespace mycms.Areas.admin.Controllers
{
    [Authorize]
    public class pagegroupsController : Controller
    {

        private IPagegrouprepository pagegrouprepository;
        mycmscontext db = new mycmscontext();
        public pagegroupsController()
        {
            pagegrouprepository = new pagegrouprepository(db);
        }
            // GET: admin/pagegroups
        public ActionResult Index()
        {
            return View(pagegrouprepository.getallgroups()) ;
        }

        // GET: admin/pagegroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = pagegrouprepository.getgroupbyid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pagegroup);
        }

        // GET: admin/pagegroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: admin/pagegroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "groupid,grouptitle")] pagegroup pagegroup)
        {
            if (ModelState.IsValid)
            {
                pagegrouprepository.insertgroup(pagegroup);
                pagegrouprepository.save();
            
                return RedirectToAction("Index");
            }

            return View(pagegroup);
        }

        // GET: admin/pagegroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = pagegrouprepository.getgroupbyid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pagegroup);
        }

        // POST: admin/pagegroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "groupid,grouptitle")] pagegroup pagegroup)
        {
            if (ModelState.IsValid)
            {
                pagegrouprepository.updategroup(pagegroup);
                pagegrouprepository.save();
                return RedirectToAction("Index");
            }
            return View(pagegroup);
        }

        // GET: admin/pagegroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = pagegrouprepository.getgroupbyid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pagegroup);
        }

        // POST: admin/pagegroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pagegrouprepository.deletegroup(id);
            pagegrouprepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pagegrouprepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
