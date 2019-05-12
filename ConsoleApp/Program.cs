using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DAL;
using Entity;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbBlog = new DbBlog();

            dbBlog.AddOrUpdate(new Blog
            {
                Id = 1,
                Owner = new Person { Name = "1111", EnglishName = "one", Email = "one@o.com" },
                Posts = new List<Post> { new Post { Content = "1111111", Title = "title111" }, new Post { Content = "2222", Title = "title222" } },
                Tags = new string[] { "1", "2", "3" },
                Url = "url1111"
            });
            dbBlog.AddOrUpdate(new Blog
            {
                Owner = new Person { Name = "222", EnglishName = "222", Email = "one@o.com" },
                Posts = new List<Post> { new Post { Content = "1111111", Title = "title111",CreatedTime=DateTime.Now,ModifiedTime=DateTime.Now }, new Post { Content = "2222", Title = "title222", CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now } },
                Tags = new string[] { "1", "2", "3" },
                Url = "url1111"
            });


            var d =  dbBlog.GetListByOwner("222");

            foreach (var j in d)
            {
               var k= dbBlog.GetModel(j.Id);
                Console.WriteLine(JsonConvert.SerializeObject(new { k.Id, k.Owner, k.Tags, k.Url, Posts= k.Posts.Select(b => new { b.Id, b.Content, b.BlogId, b.Title }) }));
            }

            Console.WriteLine();

            var data = from q in dbBlog.GetList()
                       select new
                       {
                           q.Id,
                           q.Owner,
                           Posts = q.Posts.Select(k =>new 
                           {
                               k.Id,
                               k.Content,
                               k.BlogId,
                               k.Title
                           }),
                           q.Tags,
                           q.Url
                       };
         
            foreach(var blog in data)
            {
                if (blog.Id == 1) continue;
                dbBlog.Delete(blog.Id);
            }

            Console.WriteLine(JsonConvert.SerializeObject(data));

            Console.ReadKey();
           
        }
    }
}
