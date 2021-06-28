using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer
{
   public class mycmscontext : DbContext
    {
        public DbSet<pagegroup> pagegroups { get; set; }
        public DbSet<page> pages { get; set; }
        public DbSet<pagecomment> pagecomments { get; set; }
        public DbSet<adminlogin> adminlogins { get; set; }
    }
}
