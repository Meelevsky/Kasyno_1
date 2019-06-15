namespace Kasyno_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Osoba",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        PESEL = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Katalog",
                c => new
                    {
                        NazwaGry = c.String(nullable: false, maxLength: 128),
                        OpisGry = c.String(),
                    })
                .PrimaryKey(t => t.NazwaGry);
            
            CreateTable(
                "dbo.OpisStanu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IloscGier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumerStolu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zdarzenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumerStolu = c.Int(nullable: false),
                        Gra_NazwaGry = c.String(maxLength: 128),
                        Gracz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Katalog", t => t.Gra_NazwaGry)
                .ForeignKey("dbo.Osoba", t => t.Gracz_Id)
                .Index(t => t.Gra_NazwaGry)
                .Index(t => t.Gracz_Id);
            
            CreateTable(
                "dbo.StolOpisStanu",
                c => new
                    {
                        Stol_Id = c.Int(nullable: false),
                        OpisStanu_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stol_Id, t.OpisStanu_Id })
                .ForeignKey("dbo.Stol", t => t.Stol_Id, cascadeDelete: true)
                .ForeignKey("dbo.OpisStanu", t => t.OpisStanu_Id, cascadeDelete: true)
                .Index(t => t.Stol_Id)
                .Index(t => t.OpisStanu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zdarzenie", "Gracz_Id", "dbo.Osoba");
            DropForeignKey("dbo.Zdarzenie", "Gra_NazwaGry", "dbo.Katalog");
            DropForeignKey("dbo.StolOpisStanu", "OpisStanu_Id", "dbo.OpisStanu");
            DropForeignKey("dbo.StolOpisStanu", "Stol_Id", "dbo.Stol");
            DropIndex("dbo.StolOpisStanu", new[] { "OpisStanu_Id" });
            DropIndex("dbo.StolOpisStanu", new[] { "Stol_Id" });
            DropIndex("dbo.Zdarzenie", new[] { "Gracz_Id" });
            DropIndex("dbo.Zdarzenie", new[] { "Gra_NazwaGry" });
            DropTable("dbo.StolOpisStanu");
            DropTable("dbo.Zdarzenie");
            DropTable("dbo.Stol");
            DropTable("dbo.OpisStanu");
            DropTable("dbo.Katalog");
            DropTable("dbo.Osoba");
        }
    }
}
