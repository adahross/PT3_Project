namespace OnlineShoppingMvcWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latesttt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Book_BookId", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "Book_BookId" });
            RenameColumn(table: "dbo.Carts", name: "Book_BookId", newName: "BookID");
            AlterColumn("dbo.Carts", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "BookID");
            AddForeignKey("dbo.Carts", "BookID", "dbo.Books", "BookId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "BookID", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "BookID" });
            AlterColumn("dbo.Carts", "BookID", c => c.Int());
            RenameColumn(table: "dbo.Carts", name: "BookID", newName: "Book_BookId");
            CreateIndex("dbo.Carts", "Book_BookId");
            AddForeignKey("dbo.Carts", "Book_BookId", "dbo.Books", "BookId");
        }
    }
}
