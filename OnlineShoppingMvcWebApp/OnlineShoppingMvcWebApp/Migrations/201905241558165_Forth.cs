namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisteredUsers", "ShipAddress_AddressID", "dbo.Addresses");
            AddColumn("dbo.Addresses", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "PostCode", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Publisher", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Year", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.RegisteredUsers", "fullName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.RegisteredUsers", "userName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.RegisteredUsers", "password", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.RegisteredUsers", "role", c => c.String(nullable: false));
            AlterColumn("dbo.RegisteredUsers", "PhoneNo", c => c.String(maxLength: 12));
            AlterColumn("dbo.Orders", "PaymentType", c => c.String(nullable: false));
            AddForeignKey("dbo.RegisteredUsers", "ShipAddress_AddressID", "dbo.Addresses", "AddressID", cascadeDelete: true);
            DropColumn("dbo.Addresses", "Road");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Road", c => c.String());
            DropForeignKey("dbo.RegisteredUsers", "ShipAddress_AddressID", "dbo.Addresses");
            AlterColumn("dbo.Orders", "PaymentType", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "PhoneNo", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "role", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "password", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "userName", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "fullName", c => c.String());
            AlterColumn("dbo.Books", "Category", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "ISBN", c => c.String());
            AlterColumn("dbo.Books", "Year", c => c.String());
            AlterColumn("dbo.Books", "Publisher", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Addresses", "PostCode", c => c.String());
            AlterColumn("dbo.Addresses", "Country", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            DropColumn("dbo.Addresses", "State");
            AddForeignKey("dbo.RegisteredUsers", "ShipAddress_AddressID", "dbo.Addresses", "AddressID");
        }
    }
}
