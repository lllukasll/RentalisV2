namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatus : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO `orderstatusmodels` (`id`, `name`) VALUES
(5, 'Oczekuje na odbiór');");
        }
        
        public override void Down()
        {
        }
    }
}
