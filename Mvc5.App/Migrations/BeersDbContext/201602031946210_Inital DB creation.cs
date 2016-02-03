namespace Mvc5.App.Migrations.BeersDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDBcreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Beers");
        }
    }
}
