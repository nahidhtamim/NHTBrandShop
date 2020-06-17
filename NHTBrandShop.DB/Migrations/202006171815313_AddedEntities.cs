namespace NHTBrandShop.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Table_MainMenu",
                c => new
                    {
                        MainMenuID = c.Int(nullable: false, identity: true),
                        MainMenuName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MainMenuID);
            
            CreateTable(
                "dbo.Table_Pictures",
                c => new
                    {
                        PictureID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.PictureID);
            
            CreateTable(
                "dbo.Table_Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        MainMenuID = c.Int(nullable: false),
                        SubMenuID = c.Int(),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        ProductCode = c.String(nullable: false, maxLength: 200),
                        BuyingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegularPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductQuantity = c.Int(nullable: false),
                        Color = c.String(),
                        Config = c.String(),
                        Description = c.String(),
                        SupplierID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                        ProductStatus = c.Boolean(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Table_MainMenu", t => t.MainMenuID, cascadeDelete: true)
                .ForeignKey("dbo.Table_SubMenu", t => t.SubMenuID)
                .ForeignKey("dbo.Table_Suppliers", t => t.SupplierID, cascadeDelete: true)
                .ForeignKey("dbo.Table_Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.MainMenuID)
                .Index(t => t.SubMenuID)
                .Index(t => t.SupplierID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.ProductPictures",
                c => new
                    {
                        ProductPictureID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPictureID)
                .ForeignKey("dbo.Table_Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Table_Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Table_SubMenu",
                c => new
                    {
                        SubMenuID = c.Int(nullable: false, identity: true),
                        MainMenuID = c.Int(nullable: false),
                        SubMenuName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubMenuID)
                .ForeignKey("dbo.Table_MainMenu", t => t.MainMenuID, cascadeDelete: true)
                .Index(t => t.MainMenuID);
            
            CreateTable(
                "dbo.SubMenuPictures",
                c => new
                    {
                        SubMenuPictureID = c.Int(nullable: false, identity: true),
                        SubMenuID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubMenuPictureID)
                .ForeignKey("dbo.Table_Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Table_SubMenu", t => t.SubMenuID, cascadeDelete: true)
                .Index(t => t.SubMenuID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Table_Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 100),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Table_Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        TagTitle = c.String(nullable: false, maxLength: 50),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Table_Products", "TagID", "dbo.Table_Tags");
            DropForeignKey("dbo.Table_Products", "SupplierID", "dbo.Table_Suppliers");
            DropForeignKey("dbo.Table_Products", "SubMenuID", "dbo.Table_SubMenu");
            DropForeignKey("dbo.SubMenuPictures", "SubMenuID", "dbo.Table_SubMenu");
            DropForeignKey("dbo.SubMenuPictures", "PictureID", "dbo.Table_Pictures");
            DropForeignKey("dbo.Table_SubMenu", "MainMenuID", "dbo.Table_MainMenu");
            DropForeignKey("dbo.ProductPictures", "ProductID", "dbo.Table_Products");
            DropForeignKey("dbo.ProductPictures", "PictureID", "dbo.Table_Pictures");
            DropForeignKey("dbo.Table_Products", "MainMenuID", "dbo.Table_MainMenu");
            DropIndex("dbo.SubMenuPictures", new[] { "PictureID" });
            DropIndex("dbo.SubMenuPictures", new[] { "SubMenuID" });
            DropIndex("dbo.Table_SubMenu", new[] { "MainMenuID" });
            DropIndex("dbo.ProductPictures", new[] { "PictureID" });
            DropIndex("dbo.ProductPictures", new[] { "ProductID" });
            DropIndex("dbo.Table_Products", new[] { "TagID" });
            DropIndex("dbo.Table_Products", new[] { "SupplierID" });
            DropIndex("dbo.Table_Products", new[] { "SubMenuID" });
            DropIndex("dbo.Table_Products", new[] { "MainMenuID" });
            DropTable("dbo.Table_Tags");
            DropTable("dbo.Table_Suppliers");
            DropTable("dbo.SubMenuPictures");
            DropTable("dbo.Table_SubMenu");
            DropTable("dbo.ProductPictures");
            DropTable("dbo.Table_Products");
            DropTable("dbo.Table_Pictures");
            DropTable("dbo.Table_MainMenu");
        }
    }
}
