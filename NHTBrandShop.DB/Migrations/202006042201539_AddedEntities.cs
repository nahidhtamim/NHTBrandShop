namespace NHTBrandShop.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainMenuTable",
                c => new
                    {
                        MainMenuID = c.Int(nullable: false, identity: true),
                        MainMenuName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MainMenuID);
            
            CreateTable(
                "dbo.ProductsTable",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        MainMenuID = c.Int(nullable: false),
                        SubMenuID = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        ProductCode = c.String(nullable: false, maxLength: 200),
                        RegularPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductQuantity = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                        Description = c.String(),
                        ProductStatus = c.Boolean(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.MainMenuTable", t => t.MainMenuID, cascadeDelete: true)
                .ForeignKey("dbo.ProductsSizeTable", t => t.SizeID, cascadeDelete: true)
                .ForeignKey("dbo.SubMenuTable", t => t.SubMenuID, cascadeDelete: true)
                .Index(t => t.MainMenuID)
                .Index(t => t.SubMenuID)
                .Index(t => t.SizeID);
            
            CreateTable(
                "dbo.ProductsSizeTable",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        ProductSize = c.String(nullable: false, maxLength: 100),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.SubMenuTable",
                c => new
                    {
                        SubMenuID = c.Int(nullable: false, identity: true),
                        MainMenuID = c.Int(nullable: false),
                        SubMenuName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubMenuID)
                .ForeignKey("dbo.MainMenuTable", t => t.MainMenuID, cascadeDelete: true)
                .Index(t => t.MainMenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsTable", "SubMenuID", "dbo.SubMenuTable");
            DropForeignKey("dbo.SubMenuTable", "MainMenuID", "dbo.MainMenuTable");
            DropForeignKey("dbo.ProductsTable", "SizeID", "dbo.ProductsSizeTable");
            DropForeignKey("dbo.ProductsTable", "MainMenuID", "dbo.MainMenuTable");
            DropIndex("dbo.SubMenuTable", new[] { "MainMenuID" });
            DropIndex("dbo.ProductsTable", new[] { "SizeID" });
            DropIndex("dbo.ProductsTable", new[] { "SubMenuID" });
            DropIndex("dbo.ProductsTable", new[] { "MainMenuID" });
            DropTable("dbo.SubMenuTable");
            DropTable("dbo.ProductsSizeTable");
            DropTable("dbo.ProductsTable");
            DropTable("dbo.MainMenuTable");
        }
    }
}
