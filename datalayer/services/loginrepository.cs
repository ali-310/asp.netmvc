using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
    public class loginrepository : Iloginrepository
    {
        mycmscontext db;
        public loginrepository(mycmscontext context)
        {
            this.db = context; 
        }

   

        public bool isexistuser(string username, string password)
        {
            return db.adminlogins.Any(x => x.username == username && x.password == password);
        }
        public IEnumerable<adminlogin> getalladmins()
        {
            return db.adminlogins.ToList();
        }
        public adminlogin getadminbyid(int adminid)
        {
            return db.adminlogins.Find(adminid);
        }

        public bool Deleteadmin(int delete)
        {
            try
            {
                db.Entry(delete).State = System.Data.Entity.EntityState.Deleted;
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
    }



}
