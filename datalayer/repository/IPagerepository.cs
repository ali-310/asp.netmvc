using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public interface IPagerepository:IDisposable
    {
        IEnumerable<page> getallpage();
        page getpagebyid(int pageid);
        bool insertpage(page page);
        bool updatepage(page page);
        bool deletepage(page page);
        bool deletepage(int pageid);
        void save();
        IEnumerable<page> topnews(int take = 4);
        IEnumerable<page> pagesinslider();
        IEnumerable<page> lastnews(int take=4);
        IEnumerable<page> showpagebygroupid(int groupid);
        IEnumerable<page> searchpage(string search);


    }
}

