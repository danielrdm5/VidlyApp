namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSusbcribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSusbcribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSusbcribedToNewsLetter");
        }
    }
}
