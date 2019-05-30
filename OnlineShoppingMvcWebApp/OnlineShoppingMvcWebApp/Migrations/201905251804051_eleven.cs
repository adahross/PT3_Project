namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleven : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Carts", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.Carts", name: "Order_OrderId", newName: "OrderID");
            AlterColumn("dbo.Carts", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "OrderID");
            AddForeignKey("dbo.Carts", "OrderID", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "OrderID", "dbo.Orders");
            DropIndex("dbo.Carts", new[] { "OrderID" });
            AlterColumn("dbo.Carts", "OrderID", c => c.Int());
            RenameColumn(table: "dbo.Carts", name: "OrderID", newName: "Order_OrderId");
            CreateIndex("dbo.Carts", "Order_OrderId");
            AddForeignKey("dbo.Carts", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
