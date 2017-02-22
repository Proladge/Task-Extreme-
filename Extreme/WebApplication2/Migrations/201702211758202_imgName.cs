namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "imgName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "imgName");
        }
    }
}
