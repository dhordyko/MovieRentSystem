namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userroles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [RegisterViewModeld], [CssTheme], [BirthDate], [MembershipTypeId], [FirstName], [SecondName], [Address], [Phone]) VALUES (N'd8e76299-9751-4c34-88cd-0ea92d34582f', N'superadmin@gmail.com', 0, N'AIZ7JXFzLV9KJn0D6tPnfmG282+xZwT/LbqLI8w3urtPjlzKsF1CAgqyb8rIeJ1S4w==', N'd375d8b5-45a3-46bd-99eb-ee3a8aa16b4d', NULL, 0, 0, NULL, 1, 0, N'superadmin@gmail.com', 0, NULL, N'1987-03-12 00:00:00', 0, N'Darya', N'Khordykova', N'Kustronia 24/9,Rzeszów,35-303', 570461982)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [RegisterViewModeld], [CssTheme], [BirthDate], [MembershipTypeId], [FirstName], [SecondName], [Address], [Phone]) VALUES (N'f895ad0c-1657-439c-8c82-265e9c13c786', N'kora@gmail.com', 0, N'APUG6tYQtIDCUNGA9cBFUf40drapq/ndQ9apts0aGvXJbx5wvZ1KwyKKrhgBCXfTCQ==', N'a0fefe6e-9bbc-497d-961e-40845c4068d5', NULL, 0, 0, NULL, 1, 0, N'kora@gmail.com', 0, NULL, N'1987-03-12 00:00:00', 2, N'Wera', N'Kora', N'asdfasdf,asdfs34', 123345)
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f7803f07-0609-4f00-b779-93e15d2befa1', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd8e76299-9751-4c34-88cd-0ea92d34582f', N'f7803f07-0609-4f00-b779-93e15d2befa1')



");
        }
        
        public override void Down()
        {
        }
    }
}
