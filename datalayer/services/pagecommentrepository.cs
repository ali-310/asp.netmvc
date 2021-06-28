using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
  public  class pagecommentrepository : IPagecommentrepository
    {
       private mycmscontext db;
      
        public pagecommentrepository(mycmscontext context)
        {
            db = context;

        }
        public IEnumerable<pagecomment> getcommentsbynewsid(int id)
        {
            return db.pagecomments.Where(x => x.pageid==id);
        }
        public bool addcomment(pagecomment comment)
        {
            try
            {
                db.pagecomments.Add(comment);
                db.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

     
    }
}
