using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    public interface IDataService
    {
        IEnumerable<Katalog> WszystkiePozycjeKatalogu();
        IEnumerable<Katalog> PrzeszukajlKatalog(string nazwaGry);
        void DodajZdarzenie(Zdarzenie zdarzenie);
        IEnumerable<Zdarzenie> WyswietlPowiazaneZdarzenia();
        IEnumerable<Gracz> WyswietlWszystkichGraczy();
        IEnumerable<Gracz> ZnajdzGracza(string nazwisko);
        
    }
}
