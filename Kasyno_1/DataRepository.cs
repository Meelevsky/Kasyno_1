using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace Kasyno_1
{
    public class DataRepository : IRepositoryGracz, IRepositoryKatalog, IRepositoryStan, IRepositoryZdarzenie
    {

        private DataContext kontekst = new DataContext();

        public DataRepository()
        {
        }

        
        public DataRepository(IWypelnianieStalymi wypelnianie)
        {
            kontekst.WypelnijOsoby(wypelnianie.PobierzGraczy());
            kontekst.WypelnijSlownik(wypelnianie.PobierzGry());
            kontekst.WypelnijStany(wypelnianie.PobierzStan());
            kontekst.WypelnijZdarzenia(wypelnianie.PobierzZdarzenie());
        }

        public void AddGracz(Gracz gracz)
        {
            kontekst.Osoby.Add(gracz);
        }

        public void AddKatalog(Katalog katalog)
        {
            kontekst.Katalog.Add(katalog.NazwaGry, katalog);
        }

        public void AddStan(OpisStanu stan)
        {
            kontekst.OpisyStanow.Add(stan);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            kontekst.Zdarzenia.Add(zdarzenie);
        }

        public void DeleteGracz(int Id)
        {
            kontekst.Osoby.Remove(kontekst.Osoby.First(x => x.Id == Id));
        }

        public void DeleteKatalog(string Id)
        {
            kontekst.Katalog.Remove(Id);
        }

        public void DeleteStan(int Id)
        {
            kontekst.OpisyStanow.Remove(kontekst.OpisyStanow.First(x => x.Id == Id));
        }

        public void DeleteZdarzenie(int Id)
        {
            kontekst.Zdarzenia.Remove(kontekst.Zdarzenia.First(x => x.Id == Id));
        }

        public Gracz[] GetAllGracz()
        {
            return kontekst.Osoby.Select(osoba => osoba as Gracz).ToArray();
        }

        public Katalog[] GetAllKatalog()
        {
            return kontekst.Katalog.Select(katalog => katalog.Value).ToArray();
        }

        public OpisStanu[] GetAllStan()
        {
            return kontekst.OpisyStanow.ToArray();
        }

        public Zdarzenie[] GetAllZdarzenie()
        {
            return kontekst.Zdarzenia.ToArray();
        }

        public Gracz GetGracz(int Id)
        {
            return kontekst.Osoby.FirstOrDefault(osoba => osoba.Id == Id) as Gracz;
        }

        public Katalog GetKatalog(string NazwaGry)
        {
            return kontekst.Katalog.FirstOrDefault(x => x.Key == NazwaGry).Value;
        }

        public OpisStanu GetStan(int Id)
        {
            return kontekst.OpisyStanow.FirstOrDefault(stan => stan.Id == Id);
        }

        public Zdarzenie GetZdarzenie(int Id)
        {
            return kontekst.Zdarzenia.FirstOrDefault(zdarzenie => zdarzenie.Id == Id);
        }

        public Gracz UpdateGracz(Gracz gracz)
        {
            
            throw new NotImplementedException();
        }

        public Katalog UpdateKatalog(Katalog katalog)
        {
            throw new NotImplementedException();
        }

        public OpisStanu UpdateStan(OpisStanu stan)
        {
            throw new NotImplementedException();
        }

        public Zdarzenie UpdateZdarzenie(Zdarzenie zdarzenie)
        {
            throw new NotImplementedException();
        }
    }
}
