using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kasyno_1
{
    public class Katalog
    {
        [Key]
        public string NazwaGry { get; set; }
        public string OpisGry { get; set; }
    }
}
