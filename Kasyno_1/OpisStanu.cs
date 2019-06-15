using System;
using System.Collections.Generic;
using System.Text;

namespace Kasyno_1
{
    public class OpisStanu
    {
        public int Id { get; set; }
        public int IloscGier { get; set; }
        public virtual ICollection<Stol> Stoly { get; set; }
    }
}
