using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public interface Iloginrepository
    {
        
        bool isexistuser(string username,string password);
        IEnumerable<adminlogin> getalladmins();
        adminlogin getadminbyid(int adminid);

        bool Deleteadmin(int delete);
        void save();
    }
}
