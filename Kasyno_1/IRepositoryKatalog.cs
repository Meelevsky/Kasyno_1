using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    interface IRepositoryKatalog
    {
        void AddKatalog(Katalog katalog);
        Katalog GetKatalog(string NazwaGry);
        Katalog[] GetAllKatalog();
        Katalog UpdateKatalog(Katalog katalog);
        void DeleteKatalog(string NazwaGry);
    }
}
