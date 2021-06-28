using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public interface IPagecommentrepository
    {
        IEnumerable<pagecomment> getcommentsbynewsid(int id);
        bool addcomment(pagecomment comment);
    }
}
