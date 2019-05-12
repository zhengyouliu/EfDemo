namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TestCodeFirsts");
            AlterColumn("dbo.TestCodeFirsts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TestCodeFirsts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TestCodeFirsts");
            AlterColumn("dbo.TestCodeFirsts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TestCodeFirsts", "Id");
        }
    }
}
