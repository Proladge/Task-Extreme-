namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dele : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "backgroundImg");
            DropColumn("dbo.Services", "imgName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "imgName", c => c.String());
            AddColumn("dbo.Posts", "backgroundImg", c => c.String());
        }
    }
}
