namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Street = c.String(nullable: false, maxLength: 128),
                        Road = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Street);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Publisher = c.String(),
                        Year = c.String(),
                        CoverPage = c.String(),
                        ISBN = c.String(),
                        Author = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        registeredUserId = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        password = c.String(),
                        role = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ShipAddress_Street = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.registeredUserId)
                .ForeignKey("dbo.Addresses", t => t.ShipAddress_Street)
                .Index(t => t.ShipAddress_Street);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        ShipFee = c.Double(nullable: false),
                        Customer_registeredUserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.RegisteredUsers", t => t.Customer_registeredUserId)
                .Index(t => t.Customer_registeredUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_registeredUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.RegisteredUsers", "ShipAddress_Street", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "Customer_registeredUserId" });
            DropIndex("dbo.RegisteredUsers", new[] { "ShipAddress_Street" });
            DropTable("dbo.Orders");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Books");
            DropTable("dbo.Addresses");
        }
    }
}
