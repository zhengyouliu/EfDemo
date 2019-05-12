namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Url = c.String(),
                    CreateTime = c.DateTime(),
                    Double = c.Double(nullable: false),
                    Float = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TestCodeFirsts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestCodeFirsts");
            DropTable("dbo.Blogs");
        }
    }
}
