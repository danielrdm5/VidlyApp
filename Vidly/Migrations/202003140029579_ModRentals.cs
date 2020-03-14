namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModRentals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Rentals", "Customer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Customer", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropColumn("dbo.Rentals", "Customer_Id");
        }
    }
}
