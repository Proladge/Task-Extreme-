namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeLimit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "TimeLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "TimeLimit");
        }
    }
}
