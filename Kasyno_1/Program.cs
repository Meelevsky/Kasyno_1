using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Kasyno_1
{

    public class KasynoContext : DbContext
    {
        public DbSet<Gracz> Gracze { get; set; }
        public DbSet<Katalog> Gry { get; set; }
        public DbSet<OpisStanu> OpisyStanow { get; set; }
        public DbSet<Zdarzenie> Zdarzenia { get; set; }
        public DbSet<Stol> Stoly { get; set; }

        public KasynoContext() : base("name=Kasyno")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dr = new DataRepository(new WypelnianieStalymi());
            var ds = new DataService(dr);

            using (var db = new KasynoContext())
            {

                ICollection<Stol> numerStolow = new List<Stol>();

                var gamer = new Gracz { Id = 1, Imie = "Maciej", Nazwisko = "Milewski", PESEL = "90072105756" };
                var game = new Katalog { NazwaGry = "Rosyjska ruletka", OpisGry = "Strzelaj! Poki masz szczescie" };
                var state = new OpisStanu { Id = 3, IloscGier = 2, Stoly = numerStolow };
                var events = new Zdarzenie { Id = 2, Gracz = gamer, Gra = game, NumerStolu = 3 };

                

                db.Gracze.Add(gamer);
                db.Gry.Add(game);
                db.OpisyStanow.Add(state);
                db.Zdarzenia.Add(events);
                db.SaveChanges();


            }

                var katalog = ds.WszystkiePozycjeKatalogu();
            var gra = ds.PrzeszukajlKatalog("Roulette").First();

            var gracze = ds.WyswietlWszystkichGraczy();
            var gracz = ds.ZnajdzGracza("Milewski").First();

            var zdarzenia = ds.WyswietlPowiazaneZdarzenia();
            //zdarzenia powinny miec autonumerowane id
            //pozostałe obiekty tez ;)

            ds.DodajZdarzenie(new Zdarzenie() { Gra = gra, Gracz = gracz, NumerStolu = 1, Id = 3 });
            ds.DodajZdarzenie(new Zdarzenie() { Gra = gra, Gracz = gracz, NumerStolu = 1, Id = 4 });

            ds.WyswietlPowiazaneZdarzenia();



            //var dr2 = new DataRepository(new WypelnianieStalymiJSON());
            //var d2s = new DataService(dr2);
            //... to samo co powyzej tylko dla innego zrodla danych ...


            Console.WriteLine("THE END");
            Console.ReadKey();
        }
    }
}
