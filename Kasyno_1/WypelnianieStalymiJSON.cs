using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kasyno_1
{
    class WypelnianieStalymiJSON : IWypelnianieStalymi
    {
        public Gracz[] PobierzGraczy()
        {
            return JsonConvert.DeserializeObject<Gracz[]>(File.ReadAllText(@"C:\Users\milan\source\repos\Meelevsky\Kasyno_1\Kasyno_1\JSON\Gracze.json"));
        }

        public Katalog[] PobierzGry()
        {
            return JsonConvert.DeserializeObject<Katalog[]>(File.ReadAllText(@"C:\Users\milan\source\repos\Meelevsky\Kasyno_1\Kasyno_1\JSON\Gry.json"));
            

        }

        public OpisStanu[] PobierzStan()
        {
            Random rnd = new Random();
            return new[]
            {
                new OpisStanu{Id = 1, IloscGier = rnd.Next(1,5) },
                new OpisStanu{Id = 2, IloscGier = rnd.Next(1,5) }
            };
        }

        public Zdarzenie[] PobierzZdarzenie()
        {
            return new[]
            {
                new Zdarzenie{Id = 1, Gracz = PobierzGraczy()[0], Gra = PobierzGry()[0], NumerStolu = 1 },
                new Zdarzenie{Id = 2, Gracz = PobierzGraczy()[0], Gra = PobierzGry()[1], NumerStolu = 2 }
        };
        }
    }
}
