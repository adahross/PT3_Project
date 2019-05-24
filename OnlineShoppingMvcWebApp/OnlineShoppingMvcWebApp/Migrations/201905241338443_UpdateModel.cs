namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredUsers", "fullname", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Date");
            DropColumn("dbo.RegisteredUsers", "fullname");
        }
    }
}
