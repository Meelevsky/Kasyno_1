using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasyno_1
{
    public class Stol
    {
        public int Id { get; set; }
        public int NumerStolu{ get; set; }

        public virtual ICollection<OpisStanu> OpisyStanow { get; set; }
    }
}
