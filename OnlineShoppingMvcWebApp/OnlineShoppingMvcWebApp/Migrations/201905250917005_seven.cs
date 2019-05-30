namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_registeredUserId", "dbo.RegisteredUsers");
            DropIndex("dbo.Orders", new[] { "Customer_registeredUserId" });
            RenameColumn(table: "dbo.Orders", name: "Customer_registeredUserId", newName: "OrderCustomerid");
            AlterColumn("dbo.Orders", "OrderCustomerid", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OrderCustomerid");
            AddForeignKey("dbo.Orders", "OrderCustomerid", "dbo.RegisteredUsers", "registeredUserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderCustomerid", "dbo.RegisteredUsers");
            DropIndex("dbo.Orders", new[] { "OrderCustomerid" });
            AlterColumn("dbo.Orders", "OrderCustomerid", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "OrderCustomerid", newName: "Customer_registeredUserId");
            CreateIndex("dbo.Orders", "Customer_registeredUserId");
            AddForeignKey("dbo.Orders", "Customer_registeredUserId", "dbo.RegisteredUsers", "registeredUserId");
        }
    }
}
