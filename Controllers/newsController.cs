using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datalayer;

namespace mycms
{
    public class newsController : Controller
    {
        // GET: news
        private mycmscontext db = new mycmscontext();
        private IPagegrouprepository pagegrouprepository;
        private IPagerepository pagerepository;
        private IPagecommentrepository Pagecommentrepository;
        public newsController()
        {
            pagegrouprepository = new pagegrouprepository(db);
            pagerepository = new pagerepository(db);
            Pagecommentrepository = new pagecommentrepository(db);
        }
        public ActionResult showgroups()
        {
            return PartialView(pagegrouprepository.Getgroupsforview());
        }
        public ActionResult showgroupsinmenu()
        {
            return PartialView(pagegrouprepository.getallgroups());
        }
        public ActionResult showtopnews()
        {
            return PartialView(pagerepository.topnews());
        }
        public ActionResult latenews()
        {
            return PartialView(pagerepository.lastnews());
        }
        [Route("archive")]
        public ActionResult archivenews()
        {
            return PartialView(pagerepository.getallpage());
        }
        [Route("group/{id}/{title}")]
        public ActionResult shownewsbygroupid(int id,string title)
        {
            ViewBag.name = title;
            return View(pagerepository.showpagebygroupid(id));
        }
        [Route("news/{id}")]
        public ActionResult shownews(int id)
        {
            var news = pagerepository.getpagebyid(id);
            if(news==null)
            {
                return HttpNotFound();
            }
            news.visit += 1;
            pagerepository.updatepage(news);
            pagerepository.save();
            return View(news);
        }
        public ActionResult addcomment(int id,string name,string email,string comment)
        {
            pagecomment pc = new pagecomment() { 
            createdate=DateTime.Now,
            pageid=id,
            comment=comment,
            email=email,
            name=name
            
            };
            Pagecommentrepository.addcomment(pc);
            return PartialView("showcomments", Pagecommentrepository.getcommentsbynewsid(id));
        }
        public ActionResult showcomments(int id)
        {
            return PartialView(Pagecommentrepository.getcommentsbynewsid(id));
        }
    }
}