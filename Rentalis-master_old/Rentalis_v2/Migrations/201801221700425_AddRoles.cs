namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO `aspnetusers` (`Id`, `Email`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEndDateUtc`, `LockoutEnabled`, `AccessFailedCount`, `UserName`) VALUES
('8fb01ffd-2bda-4c0e-8dab-dc098ad4ab2e', 'admin@email.com', 0, 'AEWhPkUaytfr8o2Kfsxbytqh1CX6mpjUBiHWeiYqREZ/aOOTE7sV7ssxJrGk10fkTg==', 'bda3cb85-9827-4a8b-84d8-d1a5a8470b22', NULL, 0, 0, NULL, 1, 0, 'admin@email.com');");

            Sql(@"INSERT INTO `aspnetroles` (`Id`, `Name`) VALUES ('5af67c0a-397b-4d84-b3a2-5036866f5e21', 'Admin');");
            Sql(@"INSERT INTO `aspnetroles` (`Id`, `Name`) VALUES ('56554d5f-d66a-41a1-9c14-f91b7d958f55', 'SuperAdmin');");
            Sql(@"INSERT INTO `aspnetroles` (`Id`, `Name`) VALUES ('63227c9a-9a78-44c3-bba8-0b29366ae81d', 'User');");

            Sql(@"INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('8fb01ffd-2bda-4c0e-8dab-dc098ad4ab2e', '56554d5f-d66a-41a1-9c14-f91b7d958f55');");

        }
        
        public override void Down()
        {
        }
    }
}
