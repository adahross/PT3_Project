namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisteredUsers", "ShipAddress_Street", "dbo.Addresses");
            DropIndex("dbo.RegisteredUsers", new[] { "ShipAddress_Street" });
            RenameColumn(table: "dbo.RegisteredUsers", name: "ShipAddress_Street", newName: "ShipAddress_AddressID");
            DropPrimaryKey("dbo.Addresses");
            AddColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "ShipAddress_AddressID", c => c.Int());
            AddPrimaryKey("dbo.Addresses", "AddressID");
            CreateIndex("dbo.RegisteredUsers", "ShipAddress_AddressID");
            AddForeignKey("dbo.RegisteredUsers", "ShipAddress_AddressID", "dbo.Addresses", "AddressID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisteredUsers", "ShipAddress_AddressID", "dbo.Addresses");
            DropIndex("dbo.RegisteredUsers", new[] { "ShipAddress_AddressID" });
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.RegisteredUsers", "ShipAddress_AddressID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Addresses", "AddressID");
            AddPrimaryKey("dbo.Addresses", "Street");
            RenameColumn(table: "dbo.RegisteredUsers", name: "ShipAddress_AddressID", newName: "ShipAddress_Street");
            CreateIndex("dbo.RegisteredUsers", "ShipAddress_Street");
            AddForeignKey("dbo.RegisteredUsers", "ShipAddress_Street", "dbo.Addresses", "Street");
        }
    }
}
