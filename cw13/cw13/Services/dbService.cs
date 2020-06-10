using cw13.DTOs;
using cw13.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Services
{
    public class dbService : IdbService
    {
        public string AddZamowienie(EnrollZamowienieRequest enza, int id)
        {
            var db = new s18625Context();
            var zam = new Zamowienie
            {
                IdZamowienie = enza.IdZamowienia,
                DataZamowienia = enza.DataPrzyjecia,
                DataRealizacji = enza.DataRealizacji,
                Uwagi = enza.Uwagi,
                KlientIdKleint = id,
                PracownikIdPracownik = enza.IdPracownik,
                


            };

            var exist = db.WyrobCukierniczy
               .Any(wc => wc.Nazwa == enza.wyrob);
            if (!exist)
            {
                return "Bład: Ten Wyrob nie figuruje na naszej liscie wurobów cukierniczych";
            }

            db.Zamowienie.Add(zam);
            db.SaveChanges();
            return "zamowienie przyjete";
            
        }

        

        public List<Zamowienie> GetZamowienies(string naz)
        {
            
            var db = new s18625Context();
            try
            {


       //         var objects = from klients in db.Klient
         //                     join zamowienias in db.Zamowienie on klients.IdKleint equals zamowienias.KlientIdKleint
           //                   select zamowienias.DataZamowienia +" "+zamowienias.DataRealizacji;


                var id = db.Klient
                    .Where(k => k.Nazwisko.Equals(naz))
                    .Select(k => k.IdKleint)
                    .First();

                var zamowienies = db.Zamowienie
                    .Where(z => z.KlientIdKleint == id)
                    .ToList();
                return zamowienies;
            }
            catch (Exception)
            {
               
                return null;
            }

        }

        public List<Zamowienie> GetZamowienies()
        {
            var db = new s18625Context();
            var res = db.Zamowienie
                .ToList();
                

            return res;  
            
        }
    }
}
