using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    interface IRepositoryZdarzenie
    {
        void AddZdarzenie(Zdarzenie zdarzenie);
        Zdarzenie GetZdarzenie(int Id);
        Zdarzenie[] GetAllZdarzenie();
        Zdarzenie UpdateZdarzenie(Zdarzenie zdarzenie);
        void DeleteZdarzenie(int Id);
    }
}
