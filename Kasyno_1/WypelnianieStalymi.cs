using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1

{
    public class WypelnianieStalymi : IWypelnianieStalymi
    {
        public Katalog[] PobierzGry()
        {
            return new[]
            {
                new Katalog {NazwaGry = "Black Jack", OpisGry = "Zbierz karty do wartości 21"},
                new Katalog {NazwaGry = "Roulette", OpisGry = "Obstaw liczbę, kolor, partię i sprawdź czy wygrałeś" }
            };
        }

        public OpisStanu[] PobierzStan()
        {
            return new[]
            {
                new OpisStanu{Id = 1, IloscGier = 5},
                new OpisStanu{Id = 2, IloscGier = 2 }
            };
        }

        public Zdarzenie[] PobierzZdarzenie()
        {
            return new[]
            {
                new Zdarzenie{Id = 1, Gracz = PobierzGraczy()[0], Gra = PobierzGry()[0], NumerStolu = 1 },
                new Zdarzenie{Id = 2, Gracz = PobierzGraczy()[0], Gra = PobierzGry()[1], NumerStolu = 2 },
            };
        }

        public Gracz[] PobierzGraczy()
        {
            return new[]
            {
                new Gracz { Id = 1, Imie = "Maciej", Nazwisko = "Milewski", PESEL = "90072105756" },
                new Gracz { Id = 2, Imie = "Daniel", Nazwisko = "Gierach", PESEL = "91072008524" },
            };
        }
    }
}
