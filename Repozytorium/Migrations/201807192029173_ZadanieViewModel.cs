namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZadanieViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZadanieViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 50),
                        Termin = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZadanieViewModel");
        }
    }
}
