using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using datalayer;

namespace mycms.Areas.admin.Controllers
{
    public class adminController : Controller
    {
        private mycmscontext db = new mycmscontext();
        Iloginrepository loginrepository;
        public adminController()
        {
            loginrepository = new loginrepository(db);
        }

        // GET: admin/adminlogins
        
        public ActionResult Index()
        {   
            return View(loginrepository.getalladmins());
        }

        // GET: admin/adminlogins/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminlogin adminlogin = loginrepository.getadminbyid(id.Value);
            if (adminlogin == null)
            {
                return HttpNotFound();
            }
            return View(adminlogin);
        }

        // GET: admin/adminlogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/adminlogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "loginid,username,email,password")] adminlogin adminlogin)
        {
            if (ModelState.IsValid)
            {
               
                db.adminlogins.Add(adminlogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminlogin);
        }

        // GET: admin/adminlogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminlogin adminlogin = db.adminlogins.Find(id);
            if (adminlogin == null)
            {
                return HttpNotFound();
            }
            return View(adminlogin);
        }

        // POST: admin/adminlogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "loginid,username,email,password")] adminlogin adminlogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminlogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminlogin);
        }

        // GET: admin/adminlogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminlogin adminlogin = db.adminlogins.Find(id);
            if (adminlogin == null)
            {
                return HttpNotFound();
            }
            return View(adminlogin);
        }

        // POST: admin/adminlogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adminlogin adminlogin = db.adminlogins.Find(id);
            db.adminlogins.Remove(adminlogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
