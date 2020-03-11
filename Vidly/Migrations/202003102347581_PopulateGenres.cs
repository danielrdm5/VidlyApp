namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(" +
                " Name) " +
                "Values " +
                "('Comedy')");

            Sql("INSERT INTO Genres(" +
                "Name) " +
                "Values " +
                "('Action')");

            Sql("INSERT INTO Genres(" +
                "Name) " +
                "Values " +
                "('Terror')");

            Sql("INSERT INTO Genres(" +
                "Name) " +
                "Values " +
                "('Romance Dawn')");
        }
        
        public override void Down()
        {
        }
    }
}
