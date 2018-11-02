namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b602e36-065b-43db-93c1-cc95c0f651e0', N'guest@vidly.com', 0, N'AHEbstFTAkhw7Xc7rWF4CI024mj9qPVG0yzp6Ql1T1d2K8yij2UL8pQkGx5tNfgyew==', N'2bfce173-4f0c-4719-894f-3c785acef76e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8a1582c-e193-4aff-b210-eaa61204aa93', N'admin@vidly.com', 0, N'AJlVLfwlfXfEU43rY42rAziwkCbYNNK1UIaMHTcwNCmCksDIusbJwsFw6Zcqd2KWrw==', N'a3132ed7-5b6a-4600-8dfd-f3b62f874aaa', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8dab4780-b616-4e35-98ae-a45dc28fb471', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e8a1582c-e193-4aff-b210-eaa61204aa93', N'8dab4780-b616-4e35-98ae-a45dc28fb471')
");
        }

        public override void Down()
        {
        }
    }
}
