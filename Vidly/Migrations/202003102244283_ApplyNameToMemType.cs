namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyNameToMemType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "name");
        }
    }
}
