using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasyno_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno_1.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        DataRepository dr = new DataRepository();
        [TestMethod()]
        public void AddGraczTest()
        {
            var Id = 1;
            var Imie = "Maciej";
            var Nazwisko = "Milewski";
            var PESEL = "90072105756";
            var gracz = new Gracz { Id = Id, Imie = Imie, Nazwisko = Nazwisko, PESEL = PESEL };

            dr.AddGracz(gracz);
            var expectedGracz = dr.GetGracz(Id);


            Assert.AreEqual(Id, expectedGracz.Id);
            Assert.AreEqual(Imie, expectedGracz.Imie);
            Assert.AreEqual(Nazwisko, expectedGracz.Nazwisko);
            Assert.AreEqual(PESEL, expectedGracz.PESEL);
        }

        [TestMethod()]
        public void AddKatalogTest()
        {
            var nazwaGry = "Rosyjska ruletka";
            var opisGry = "Polautomatyczny rewolwer przystawiany do glowy - jak nie przezyjesz - przegrywasz";
            var gra = new Katalog { NazwaGry = nazwaGry, OpisGry = opisGry };

            dr.AddKatalog(gra);
            var expectedKatalog = dr.GetKatalog(nazwaGry);

            Assert.AreEqual(expectedKatalog.NazwaGry, nazwaGry);
            Assert.AreEqual(expectedKatalog.OpisGry, opisGry);
        }

        [TestMethod()]
        public void AddStanTest()
        {
            var Id = 1;
            var iloscGier = 10;
            IEnumerable<int> numerStolow = new List<int>();

            var stan = new OpisStanu { Id = Id, IloscGier = iloscGier, Stoly = numerStolow };

            dr.AddStan(stan);
            var expectedStan = dr.GetStan(Id);

            Assert.AreEqual(expectedStan.Id, Id);
            Assert.AreEqual(expectedStan.IloscGier, iloscGier);
            Assert.AreEqual(expectedStan.Stoly, numerStolow);
        }

        [TestMethod()]
        public void AddZdarzenieTest()
        {
            var Id = 1;
            var gracz = new Gracz();
            gracz.Id = 1;
            gracz.Imie = "Maciej";
            gracz.Nazwisko = "Milewski";
            gracz.PESEL = "90072105756";
            var gra = new Katalog();
            gra.NazwaGry = "Rosyjska ruletka";
            gra.OpisGry = "Traf na kule, bedziesz mial pecha";
            var numerStolu = 5;

            var zdarzenie = new Zdarzenie { Id = Id, Gracz = gracz, Gra = gra, NumerStolu = numerStolu };

            dr.AddZdarzenie(zdarzenie);
            var expectedZdarzenie = dr.GetZdarzenie(Id);

            Assert.AreEqual(expectedZdarzenie.Id, Id);
            Assert.AreEqual(expectedZdarzenie.Gracz, gracz);
            Assert.AreEqual(expectedZdarzenie.Gra, gra);
            Assert.AreEqual(expectedZdarzenie.NumerStolu, numerStolu);

            //sprawdzamy wyrywkowo, czy na pewno add i get działają
            Console.WriteLine(Convert.ToString(expectedZdarzenie.Id) + expectedZdarzenie.Gracz.Imie + expectedZdarzenie.Gra.NazwaGry + Convert.ToString(expectedZdarzenie.NumerStolu));
        }

        [TestMethod()]
        public void DeleteGraczTest()
        {
            var Id = 1;
            var Imie = "Maciej";
            var Nazwisko = "Milewski";
            var PESEL = "90072105756";
            var gracz = new Gracz { Id = Id, Imie = Imie, Nazwisko = Nazwisko, PESEL = PESEL };

            dr.AddGracz(gracz);
            dr.DeleteGracz(gracz.Id = Id);
            var expectedGracz = dr.GetGracz(Id);

            Assert.IsNull(expectedGracz);

        }

        [TestMethod()]
        public void DeleteKatalogTest()
        {
            var nazwaGry = "Rosyjska ruletka";
            var opisGry = "Polautomatyczny rewolwer przystawiany do glowy - jak nie przezyjesz - przegrywasz";
            var gra = new Katalog { NazwaGry = nazwaGry, OpisGry = opisGry };

            dr.AddKatalog(gra);
            dr.DeleteKatalog(gra.NazwaGry = nazwaGry);
            var expectedKatalog = dr.GetKatalog(nazwaGry);
            Assert.IsNull(expectedKatalog);
        }

        [TestMethod()]
        public void DeleteStanTest()
        {
            var Id = 1;
            var iloscGier = 10;
            IEnumerable<int> numerStolow = new List<int>();

            var stan = new OpisStanu { Id = Id, IloscGier = iloscGier, Stoly = numerStolow };

            dr.AddStan(stan);
            dr.DeleteStan(stan.Id = Id);
            var expectedStan = dr.GetStan(Id);
            Assert.IsNull(expectedStan);
        }

        [TestMethod()]
        public void DeleteZdarzenieTest()
        {
            var Id = 1;
            var gracz = new Gracz();
            gracz.Id = 1;
            gracz.Imie = "Maciej";
            gracz.Nazwisko = "Milewski";
            gracz.PESEL = "90072105756";
            var gra = new Katalog();
            gra.NazwaGry = "Rosyjska ruletka";
            gra.OpisGry = "Traf na kule, bedziesz mial pecha";
            var numerStolu = 5;

            var zdarzenie = new Zdarzenie { Id = Id, Gracz = gracz, Gra = gra, NumerStolu = numerStolu };

            dr.AddZdarzenie(zdarzenie);
            dr.DeleteZdarzenie(zdarzenie.Id = Id);
            var expectedZdarzenie = dr.GetZdarzenie(Id);
            Assert.IsNull(expectedZdarzenie);
        }

        [TestMethod()]
        public void GetAllGraczTest()
        {
            var Id1 = 1;
            var Imie1 = "Maciej";
            var Nazwisko1 = "Milewski";
            var PESEL1 = "90072105756";
            var gracz1 = new Gracz { Id = Id1, Imie = Imie1, Nazwisko = Nazwisko1, PESEL = PESEL1 };

            var Id2 = 2;
            var Imie2 = "Lukasz";
            var Nazwisko2 = "Sierminski";
            var PESEL2 = "90102932148";
            var gracz2 = new Gracz { Id = Id2, Imie = Imie2, Nazwisko = Nazwisko2, PESEL = PESEL2 };

            dr.AddGracz(gracz1);
            dr.AddGracz(gracz2);

            var expectedGracze = dr.GetAllGracz();

            

        }
    }
}