namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisteredUsers", "fullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisteredUsers", "fullName", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
