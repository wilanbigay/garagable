namespace Garagable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GarageSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Keyword = c.String(maxLength: 100),
                        Location = c.Geography(),
                        IsActive = c.Boolean(),
                        DateAdded = c.DateTime(),
                        Description = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GarageSaleId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GarageSales", t => t.GarageSaleId, cascadeDelete: true)
                .Index(t => t.GarageSaleId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageId = c.Int(nullable: false),
                        ImageKey = c.String(maxLength: 512),
                        SmallUrl = c.String(maxLength: 512),
                        MediumUrl = c.String(maxLength: 512),
                        TinyUrl = c.String(maxLength: 512),
                        LargeUrl = c.String(maxLength: 512),
                        LightboxUrl = c.String(maxLength: 512),
                        ThumbUrl = c.String(maxLength: 512),
                        XLargeUrl = c.String(maxLength: 512),
                        X2LargeUrl = c.String(maxLength: 512),
                        X3LargeUrl = c.String(maxLength: 512),
                        Url = c.String(maxLength: 512),
                        OriginalUrl = c.String(maxLength: 512),
                        IsVisible = c.Boolean(),
                        GarageSaleId = c.Int(),
                        ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GarageSales", t => t.GarageSaleId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.GarageSaleId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GarageSaleId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GarageSales", t => t.GarageSaleId, cascadeDelete: true)
                .Index(t => t.GarageSaleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacebookId = c.String(maxLength: 64),
                        AccessToken = c.String(maxLength: 64),
                        UserName = c.String(nullable: false, maxLength: 100),
                        HashedPassword = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 100),
                        LastActivity = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SavedSearches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        Lat = c.Double(),
                        Long = c.Double(),
                        Venue = c.Geography(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.SavedSearches", new[] { "UserId" });
            DropIndex("dbo.Schedules", new[] { "GarageSaleId" });
            DropIndex("dbo.Photos", new[] { "ItemId" });
            DropIndex("dbo.Photos", new[] { "GarageSaleId" });
            DropIndex("dbo.Items", new[] { "GarageSaleId" });
            DropIndex("dbo.GarageSales", new[] { "UserId" });
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.SavedSearches", "UserId", "dbo.Users");
            DropForeignKey("dbo.Schedules", "GarageSaleId", "dbo.GarageSales");
            DropForeignKey("dbo.Photos", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Photos", "GarageSaleId", "dbo.GarageSales");
            DropForeignKey("dbo.Items", "GarageSaleId", "dbo.GarageSales");
            DropForeignKey("dbo.GarageSales", "UserId", "dbo.Users");
            DropTable("dbo.UserRole");
            DropTable("dbo.SavedSearches");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Schedules");
            DropTable("dbo.Photos");
            DropTable("dbo.Items");
            DropTable("dbo.GarageSales");
        }
    }
}
