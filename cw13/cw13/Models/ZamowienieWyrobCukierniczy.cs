using System;
using System.Collections.Generic;

namespace cw13.Models
{
    public partial class ZamowienieWyrobCukierniczy
    {
        public int WyrobCukierniczyIdWyrobCukierniczy { get; set; }
        public int ZamowienieIdZamowienie { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }

        public virtual WyrobCukierniczy WyrobCukierniczyIdWyrobCukierniczyNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
