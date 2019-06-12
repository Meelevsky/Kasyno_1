using System;
using System.Linq;

namespace Kasyno_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dr = new DataRepository(new WypelnianieStalymi());
            var ds = new DataService(dr);

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
