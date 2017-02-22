namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddshortDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "shortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "shortDescription");
        }
    }
}
