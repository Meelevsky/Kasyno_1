using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;

namespace Kasyno_1
{
    class KasynoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWypelnianieStalymi>().To<WypelnianieStalymi>();
        }
    }
}
