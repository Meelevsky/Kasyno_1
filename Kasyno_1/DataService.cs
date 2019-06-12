using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kasyno_1
{
    class DataService : IDataService
    {
        private DataRepository dataRepository;

        //public DataService() { }
        public DataService(DataRepository repo)
        {
            dataRepository = repo;
        }

        public void DodajZdarzenie(Zdarzenie zdarzenie)
        {
            dataRepository.AddZdarzenie(zdarzenie);
        }

        public IEnumerable<Katalog> WszystkiePozycjeKatalogu()
        {
            var katalog = dataRepository.GetAllKatalog();

            Console.WriteLine($"\nKatalog zawiera {katalog.Count()} pozycji:");
            int i = 1;
            foreach (var k in katalog)
            {
                Console.WriteLine($"{i}. {k.NazwaGry} - {k.OpisGry}");
                i++;
            }
            return katalog;
        }

        public IEnumerable<Katalog> PrzeszukajlKatalog(string nazwaGry)
        {
            if(string.IsNullOrEmpty(nazwaGry))
            {
                throw new Exception("Aby preszukać Katalog nazwa gry nie może być pusta.");
            }

            var all = dataRepository.GetAllKatalog();
            var katalog = all.Where(item => item.NazwaGry.Contains(nazwaGry));

            if (katalog==null)
            {
                throw new Exception("Brak zadanej gry w Katalogu.");
            }

            Console.WriteLine($"\nWyświetl katalog dla [{nazwaGry}]:");
            int i = 1;
            foreach (var k in katalog)
            {
                Console.WriteLine($"{i}. {k.NazwaGry} - {k.OpisGry}");
                i++;
            }
            
            return katalog;
        }

        public IEnumerable<Zdarzenie> WyswietlPowiazaneZdarzenia()
        {
            Console.WriteLine("\nWyświetl powiązane zdarzenia wg. graczy:");
            var zdarzenia = dataRepository.GetAllZdarzenie();
            var gracze = dataRepository.GetAllGracz();
            var katalog = dataRepository.GetAllKatalog();

            foreach (var gracz in gracze)
            {
                Console.WriteLine($"Gracz {gracz.Id} {gracz.Imie} {gracz.Nazwisko} lat: {wiek(gracz.PESEL)}");
                var stoly = zdarzenia
                                .Where(item => item.Gracz.Id == gracz.Id).GroupBy(item => item.NumerStolu)
                                .Select(group => new { Stol = group.Key, Gry = group.ToList() })
                                .ToList();
                foreach (var s in stoly)
                {
                    Console.WriteLine($"\t Stół {s.Stol}:");
                    foreach (var gra in s.Gry)
                    {
                        Console.WriteLine($"\t\t - {gra.Gra.NazwaGry} [{gra.Id}]");
                    }
                }
            }
            return zdarzenia;
        }

        private int wiek(string pESEL)
        {
            if(String.IsNullOrEmpty(pESEL))
            {
                throw new Exception("Podano błędny PESEL.");
            }

            var rok = 0;
            int.TryParse(pESEL.Substring(0, 2), out rok);

            var r = 0;
            int.TryParse(pESEL.Substring(2, 1), out r);

            var wiek = 0;
            if (r <= 1)
            {
                wiek = DateTime.Now.Year - (1900 + rok);
            }
            else if (r <=3)
            {
                wiek = DateTime.Now.Year - (2000 + rok);
            }

            return wiek;
        }

        public IEnumerable<Gracz> WyswietlWszystkichGraczy()
        {
            var gracze = dataRepository.GetAllGracz();

            Console.WriteLine($"\nZarejestrowanych jest {gracze.Count()} graczy:");
            int i = 1;
            foreach (var g in gracze)
            {
                Console.WriteLine($"{i}. {g.Imie} {g.Nazwisko} [{g.PESEL}]");
                i++;
            }
            return gracze;
        }

        public IEnumerable<Gracz> ZnajdzGracza(string nazwisko)
        {
            if (string.IsNullOrEmpty(nazwisko))
            {
                throw new Exception("Aby znalezc Gracza należy podać nazwisko lub jego fragment.");
            }

            var all = dataRepository.GetAllGracz();
            var gracz = all.Where(item => item.Nazwisko.Contains(nazwisko));

            if (gracz == null)
            {
                throw new Exception("Brak zadanego Gracza.");
            }

            Console.WriteLine($"\nWyświetl znalezionych graczy dla [{nazwisko}]:");
            int i = 1;
            foreach (var g in gracz)
            {
                Console.WriteLine($"{i}. {g.Imie} {g.Nazwisko} - {g.PESEL}");
                i++;
            }
            
            return gracz;
        }
    }
}
