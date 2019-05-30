namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RegisteredUsers", name: "ShipAddress_AddressID", newName: "ShipAddressID");
            RenameIndex(table: "dbo.RegisteredUsers", name: "IX_ShipAddress_AddressID", newName: "IX_ShipAddressID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RegisteredUsers", name: "IX_ShipAddressID", newName: "IX_ShipAddress_AddressID");
            RenameColumn(table: "dbo.RegisteredUsers", name: "ShipAddressID", newName: "ShipAddress_AddressID");
        }
    }
}
