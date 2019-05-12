using DAL.Map;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class EfDbContext:DbContext
    {
        public EfDbContext():base("name=efdb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<TestCodeFirst>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //dynamic configurationInstance = Activator.CreateInstance(typeof(BlogMap));
            //modelBuilder.Configurations.Add(configurationInstance);

            var typeToRegisters = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typeToRegisters)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }


        //public DbSet<Blog> Blogs { get; set; }

        //public DbSet<Blog> Blogs
        //{
        //    get { return Set<Blog>(); }
        //}
        public IDbSet<Blog> Blogs { get; set; }

        public IDbSet<TestCodeFirst> TestCodeFirsts { get; set; }

        public IDbSet<Post> Posts { get; set; }
       

    }
}
