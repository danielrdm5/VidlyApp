namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemTypesName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes " +
                    "set name = 'Free'" +
                "Where Id =1");

            Sql("UPDATE MembershipTypes " +
                "set name = 'Basic'" +
                "Where Id =2");

            Sql("UPDATE MembershipTypes " +
                "set name = 'Premium'" +
                "Where Id =3");

            Sql("UPDATE MembershipTypes " +
                "set name = 'Elite'" +
                "Where Id =4");
        }

        public override void Down()
        {
        }
    }
}
