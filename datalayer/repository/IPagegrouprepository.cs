using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
  public interface IPagegrouprepository:IDisposable
    {
        IEnumerable<pagegroup> getallgroups();
        pagegroup getgroupbyid(int groupid);
        bool insertgroup(pagegroup pagegroup);
        bool updategroup(pagegroup pagegroup);
        bool deletegroup(pagegroup pagegroup);
        bool deletegroup(int pagegroup);
        void save();
        IEnumerable<showgroupnewmodel> Getgroupsforview();
    }
}
