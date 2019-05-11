using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class EfDbContext:DbContext
    {
        public EfDbContext():base("name=efdb")
        {

        }
        //public DbSet<Blog> Blogs { get; set; }

        public IDbSet<Blog> Blogs { get; set; }

        //public IDbSet<TestCodeFirst> TestCodeFirsts { get; set; }

        //public DbSet<Blog> Blogs
        //{
        //    get { return Set<Blog>(); }
        //}

    }
}
