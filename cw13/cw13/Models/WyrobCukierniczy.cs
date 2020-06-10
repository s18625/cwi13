using System;
using System.Collections.Generic;

namespace cw13.Models
{
    public partial class WyrobCukierniczy
    {
        public int IdWyrobCukierniczy { get; set; }
        public string Nazwa { get; set; }
        public int CenaZaSzt { get; set; }
        public string Typ { get; set; }
    }
}
