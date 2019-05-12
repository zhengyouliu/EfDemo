using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Entity;

namespace DAL.Map
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Posts");

            HasKey(p => p.Id);

            Property(p => p.Title).IsRequired().HasColumnType("VARCHAR").HasMaxLength(50);
        }
    }
}
