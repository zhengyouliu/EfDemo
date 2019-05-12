namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            AddColumn("dbo.Blogs", "Tags", c => c.String());
            AddColumn("dbo.Blogs", "Owner", c => c.String());
            AddColumn("dbo.Blogs", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogs", "Url", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropColumn("dbo.Blogs", "Name");
            DropColumn("dbo.Blogs", "CreateTime");
            DropColumn("dbo.Blogs", "Double");
            DropColumn("dbo.Blogs", "Float");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Float", c => c.Single(nullable: false));
            AddColumn("dbo.Blogs", "Double", c => c.Double(nullable: false));
            AddColumn("dbo.Blogs", "CreateTime", c => c.DateTime());
            AddColumn("dbo.Blogs", "Name", c => c.String());
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            AlterColumn("dbo.Blogs", "Url", c => c.String());
            DropColumn("dbo.Blogs", "ModifiedTime");
            DropColumn("dbo.Blogs", "CreatedTime");
            DropColumn("dbo.Blogs", "Owner");
            DropColumn("dbo.Blogs", "Tags");
            DropTable("dbo.Posts");
        }
    }
}
