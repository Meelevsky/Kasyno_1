using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    public interface IWypelnianieStalymi
    {
        Gracz[] PobierzGraczy();
        Katalog[] PobierzGry();
        Zdarzenie[] PobierzZdarzenie();
        OpisStanu[] PobierzStan();
    }
}
