using cw13.DTOs;
using cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Services
{
    public interface IdbService
    {
        public List<Zamowienie> GetZamowienies(string nazwisko);
        public List<Zamowienie> GetZamowienies();
        public string AddZamowienie(EnrollZamowienieRequest enza, int id);
    }
}
