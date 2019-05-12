using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Map
{
   public class BlogMap:EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");

            HasKey(p => p.Id);

            Property(p => p.Url).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);

            Property(p => p._Tags).HasColumnName("Tags");
            Property(p => p._Owner).HasColumnName("Owner");

            Ignore(p => p.Tags);
            Ignore(p => p.Owner);

            HasMany(p => p.Posts).WithRequired(q => q.Blog).HasForeignKey(k => k.BlogId).WillCascadeOnDelete(true);
        }
    }
}
