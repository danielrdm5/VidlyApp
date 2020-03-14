namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
