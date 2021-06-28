using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public class pagerepository :IPagerepository
    {
        private mycmscontext db;
        public pagerepository(mycmscontext context)
        {
            this.db = context;
        }
        public IEnumerable<page> getallpage()
        {
            return db.pages;
        }
        public page getpagebyid(int pageid)
        {
            return db.pages.Find(pageid);
        }
        public bool insertpage(page page)
        {
            try
            {
                db.pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool updatepage(page page)
        {
         
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool deletepage(page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool deletepage(int pageid)
        {
            try
            {
                var x = getpagebyid(pageid);
                deletepage(x);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<page> topnews(int take = 4)
        {
            return db.pages.OrderByDescending(x => x.visit).Take(take);
        }

        public IEnumerable<page> pagesinslider()
        {
            return db.pages.Where(x => x.showinslider == true);
        }

        public IEnumerable<page> lastnews(int take = 4)
        {
            return db.pages.OrderByDescending(x => x.createdate).Take(take);
        }

        public IEnumerable<page> showpagebygroupid(int groupid)
        {
            return db.pages.Where(x => x.groupid == groupid);
        }

        public IEnumerable<page> searchpage(string search)
        {
            return db.pages.Where(p => p.title.Contains(search) || p.shortdescription.Contains(search) || p.tag.Contains(search) || p.text.Contains(search)).Distinct();
        }
    }     
}
