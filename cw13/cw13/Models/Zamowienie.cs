using System;
using System.Collections.Generic;

namespace cw13.Models
{
    public partial class Zamowienie
    {
        public int KlientIdKleint { get; set; }
        public int PracownikIdPracownik { get; set; }
        public int IdZamowienie { get; set; }
        public DateTime DataZamowienia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string Uwagi { get; set; }

        public virtual Klient KlientIdKleintNavigation { get; set; }
        public virtual Pracownik PracownikIdPracownikNavigation { get; set; }
       
    }
}
