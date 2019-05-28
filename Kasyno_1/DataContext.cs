using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Kasyno_1
{
    public class DataContext
    {
        public List<Osoba> Osoby = new List<Osoba>();
        public Dictionary<string, Katalog> Katalog = new Dictionary<string, Katalog>();
        public ObservableCollection<Zdarzenie> Zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> OpisyStanow = new List<OpisStanu>();

        public void WypelnijOsoby(IEnumerable<Gracz> gracz)
        {
            this.Osoby = new List<Osoba>(gracz);
        }

        public void WypelnijSlownik(IEnumerable<Katalog> gry)
        {
            this.Katalog = gry.ToDictionary(key => key.NazwaGry, name => name);
        }

        public void WypelnijZdarzenia (IEnumerable<Zdarzenie> zdarzenie)
        {
            this.Zdarzenia = new ObservableCollection<Zdarzenie>(zdarzenie);
        }

        public void WypelnijStany(IEnumerable<OpisStanu> opisystanow)
        {
            this.OpisyStanow = new List<OpisStanu>(opisystanow);
        }
    }
}
