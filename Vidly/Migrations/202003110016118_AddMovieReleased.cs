namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieReleased : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Released", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Released");
        }
    }
}
