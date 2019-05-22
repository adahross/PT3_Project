namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        cartID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Book_BookId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.cartID)
                .ForeignKey("dbo.Books", t => t.Book_BookId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Book_BookId)
                .Index(t => t.Order_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "Order_OrderId" });
            DropIndex("dbo.Carts", new[] { "Book_BookId" });
            DropTable("dbo.Carts");
        }
    }
}
