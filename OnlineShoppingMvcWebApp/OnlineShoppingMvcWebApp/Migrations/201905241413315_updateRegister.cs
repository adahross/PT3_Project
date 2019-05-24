namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRegister : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisteredUsers", "fullname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisteredUsers", "fullname", c => c.Int(nullable: false));
        }
    }
}
