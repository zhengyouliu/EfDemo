using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var efDbContext=new EfDbContext())
            {
                efDbContext.Blogs.Add(new Blog
                {
                    Name = "Jeffcky",
                    Url = "http://wwww.baidu.com"
                });

                //efDbContext.TestCodeFirsts.Add(new TestCodeFirst { Name = "Andy" });

                efDbContext.SaveChanges();
            }

            using (var efDbContext = new EfDbContext())
            {
                efDbContext.Blogs.ToList().ForEach(p =>
                {
                    Console.WriteLine($"Id:{p.Id},Name:{p.Name}");
                });

                //efDbContext.TestCodeFirsts.ToList().ForEach(p =>
                //{
                //    Console.WriteLine($"Id:{p.Id},Name:{p.Name}");
                //});
            }
        }
    }
}
