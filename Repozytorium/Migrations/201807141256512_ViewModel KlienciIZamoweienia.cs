namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModelKlienciIZamoweienia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klient",
                c => new
                    {
                        KlientID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(maxLength: 100, unicode: false),
                        Addres = c.String(maxLength: 300, unicode: false),
                        Komorka = c.String(maxLength: 15, unicode: false),
                        DataUrodzenia = c.DateTime(),
                        EmailID = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.KlientID);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieID = c.Int(nullable: false, identity: true),
                        KlientID = c.Int(),
                        DataZamowienia = c.DateTime(),
                        CenaZamowienia = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.ZamowienieID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zamowienie");
            DropTable("dbo.Klient");
        }
    }
}
