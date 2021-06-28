using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using datalayer;
using System.IO;

namespace mycms.Areas.admin.Controllers
{
    [Authorize]
    public class pagesController : Controller
    {
        private IPagerepository pagerepository;
        private IPagegrouprepository pagegrouprepository;
       private mycmscontext db = new mycmscontext();
        public pagesController()
        {
            pagerepository = new pagerepository(db);
            pagegrouprepository = new pagegrouprepository(db);
        }


        // GET: admin/pages
      
        public ActionResult Index()
        {
            
            return View(pagerepository.getallpage());
        }

        // GET: admin/pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = db.pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: admin/pages/Create
        public ActionResult Create()
        {
            ViewBag.groupid = new SelectList(pagegrouprepository.getallgroups(), "groupid", "grouptitle") ;
            return View();
        }

        // POST: admin/pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pageid,groupid,title,shortdescription,text,visit,imgname,showinslider,createdate,tag")] page page,HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                page.visit = 0;
                page.createdate = DateTime.Now;
                if (imgup != null)
                {
                    page.imgname = Guid.NewGuid() +Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/pageimgs/"+page.imgname));
                }
                pagerepository.insertpage(page);
                pagerepository.save();
              
                return RedirectToAction("Index");
            }

            ViewBag.groupid = new SelectList(db.pagegroups, "groupid", "grouptitle", page.groupid);
            return View(page);
        }
       
    
        // GET: admin/pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = pagerepository.getpagebyid(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupid = new SelectList(pagegrouprepository.getallgroups(), "groupid", "grouptitle", page.groupid);
            return View(page);
        }

        // POST: admin/pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pageid,groupid,title,shortdescription,text,visit,imgname,showinslider,createdate,tag")] page page,HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                if (imgup != null)
                {
                    if (page.imgname != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/pageimgs/" + page.imgname));
                    }


                        page.imgname = Guid.NewGuid() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/pageimgs/" + page.imgname));
                }
                pagerepository.updatepage(page);
                pagerepository.save();

                return RedirectToAction("Index");
            }
            ViewBag.groupid = new SelectList(db.pagegroups, "groupid", "grouptitle", page.groupid);
            return View(page);
        }

        // GET: admin/pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page page = pagerepository.getpagebyid(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: admin/pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            page page = pagerepository.getpagebyid(id);
            if (page.imgname != null)
            {
                System.IO.File.Delete(Server.MapPath("/pageimgs/" + page.imgname));
            }
            pagerepository.deletepage(page);
            pagerepository.save();

            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
                pagegrouprepository.Dispose();
                pagerepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
