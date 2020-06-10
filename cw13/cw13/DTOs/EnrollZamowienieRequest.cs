using cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.DTOs
{
    public class EnrollZamowienieRequest
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        
        public string  Uwagi{ get; set; }
       
        public int IdPracownik { get; set; }
        public string wyrob { get; set; }
        public int ilosc { get; set; }

    }
}
