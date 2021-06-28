using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
    public class pagegrouprepository : IPagegrouprepository
    {
        private mycmscontext db;
        public pagegrouprepository(mycmscontext context)
        {
            this.db = context;
        }
        public IEnumerable<pagegroup> getallgroups()
        {
            return db.pagegroups;
        }
        public pagegroup getgroupbyid(int groupid)
        {
           
            return db.pagegroups.Find(groupid);
        }
        public bool insertgroup(pagegroup pagegroup)
        {
            try
            {
               db.pagegroups.Add(pagegroup);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool updategroup(pagegroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State =EntityState.Modified;
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool deletegroup(int pagegroup)
        {
            try
            {
                var group = getgroupbyid(pagegroup);
                deletegroup(group);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool deletegroup(pagegroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State = EntityState.Deleted;
                return true;

            }
            catch (Exception)
            {

                return false;
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

        public IEnumerable<showgroupnewmodel> Getgroupsforview()
        {
            return db.pagegroups.Select(c => new showgroupnewmodel()

            {
                groupid=c.groupid,
                grouptitle=c.grouptitle,
                pagecount=c.Pages.Count


            });
        }
    }
}
