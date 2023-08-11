namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutDetail1 = c.String(maxLength: 1000),
                        AboutDetail2 = c.String(maxLength: 1000),
                        AboutImage1 = c.String(maxLength: 100),
                        AboutImage2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 150),
                        Image = c.String(maxLength: 150),
                        Description = c.String(maxLength: 600),
                        CreatedBy = c.String(maxLength: 600),
                        CreatedOn = c.String(maxLength: 600),
                        ModifiedBy = c.String(maxLength: 600),
                        ModifiedOn = c.String(maxLength: 600),
                        DeletedBy = c.String(maxLength: 600),
                        DeletedOn = c.String(maxLength: 600),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 600),
                        CreatedOn = c.String(maxLength: 600),
                        ModifiedBy = c.String(maxLength: 600),
                        ModifiedOn = c.String(maxLength: 600),
                        DeletedBy = c.String(maxLength: 600),
                        DeletedOn = c.String(maxLength: 600),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Contacts");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
