using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    public interface IRepositoryGracz
    {
        void AddGracz(Gracz gracz);
        Gracz GetGracz(int Id);
        Gracz[] GetAllGracz();
        Gracz UpdateGracz(Gracz gracz);
        void DeleteGracz(int Id);
    }
}
