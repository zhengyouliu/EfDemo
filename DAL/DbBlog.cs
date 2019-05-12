using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DbBlog
    {
        public IList<Blog> GetList()
        {
            using( var context= new EfDbContext())
            {
                return context.Blogs.Include("Posts").AsNoTracking().ToList();
            }
        }

        public IList<Blog> GetListByOwner(string owner)
        {
            var blogs = GetList();

            blogs.All(b =>
            {
                b.Owner = JsonConvert.DeserializeObject<Person>(b._Owner);
                return true;
            });

            if (!string.IsNullOrEmpty(owner))
            {
                blogs = blogs.Where(p => p.Owner.Name == owner || p.Owner.EnglishName == owner).ToList();
            }

            return blogs;
        }

        public Blog GetModel(int id)
        {
            using (var context = new EfDbContext())
            {
                return context.Blogs.Include("Posts").AsNoTracking().First(p => p.Id==id);
            }
        }

        public bool Delete(int id)
        {
            using (var context = new EfDbContext())
            {
                var blog = context.Blogs.Find(id);
                context.Blogs.Remove(blog);

                return 0<context.SaveChanges();
            }
        }

        public bool  AddOrUpdate(Blog blog)
        {
            using (var context = new EfDbContext())
            {
                if (blog.Id <= 0)
                {
                    blog.CreatedTime = DateTime.Now;
                    blog.ModifiedTime = DateTime.Now;
                    context.Blogs.Add(blog);
                    
                }
                else
                {
                    var dbblog = context.Blogs.Find(blog.Id);

                    context.Entry(dbblog).CurrentValues.SetValues(blog);

                    dbblog.ModifiedTime = DateTime.Now;

                    dbblog.CreatedTime = DateTime.Now;
                }

                return !context.ChangeTracker.HasChanges() || 0 < context.SaveChanges();
            }
        }
    }
}
