namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b311e63-ea7d-4c87-a859-66cff6912679', N'admin@vidlyrdm.com', 0, N'AO6XajGis7UsbCwCpKafw3pyYGIgUaAMwsrO1mj36akfk3P3l6W1MoP2Txc2Cf/StA==', N'0b1f42aa-19ef-4b35-9b9d-c30416690c92', NULL, 0, 0, NULL, 1, 0, N'admin@vidlyrdm.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e8be684-66a5-42c9-af3f-2e6a2591d796', N'guest@gmail.com', 0, N'ADjjxDQGYHhVjLF9tB0SrtLjkPc8KnuLzb+AgpWkPJwQaDdBzt+DVGpdNHy9yQeBcg==', N'88b1bcbf-0890-44dc-bd8f-2cd16aa8966d', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
            ");

            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9c1fdec0-ca07-4255-9a1a-6b4a24f1f8c7', N'CanManageMovies')
            ");

            Sql(@"
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1b311e63-ea7d-4c87-a859-66cff6912679', N'9c1fdec0-ca07-4255-9a1a-6b4a24f1f8c7')
            ");

        }

        public override void Down()
        {
        }
    }
}
