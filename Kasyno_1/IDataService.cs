using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    public interface IDataService
    {
        IEnumerable<Katalog> WszystkiePozycjeKatalogu();
        IEnumerable<Zdarzenie> ZdarzeniaDlaElementuWykazu();
        IEnumerable<Zdarzenie> ZdarzeniaPomiedzyDatami();
        Zdarzenie DodajZdarzenie();
        IEnumerable<Katalog> WyswietlKatalog();
        IEnumerable<Zdarzenie> WyswietlPowiazaneZdarzenia();
    }
}
