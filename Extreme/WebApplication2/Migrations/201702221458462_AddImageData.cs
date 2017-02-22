namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ImageData", c => c.Binary());
            AddColumn("dbo.Posts", "ImageMimeType", c => c.String());
            AddColumn("dbo.Services", "ImageData", c => c.Binary());
            AddColumn("dbo.Services", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "ImageMimeType");
            DropColumn("dbo.Services", "ImageData");
            DropColumn("dbo.Posts", "ImageMimeType");
            DropColumn("dbo.Posts", "ImageData");
        }
    }
}
