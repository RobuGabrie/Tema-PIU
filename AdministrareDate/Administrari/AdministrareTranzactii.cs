using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modele.ClaseModele
{
    public class AdminTranzactii
    {
        private static readonly string filePath = "tranzactii.json";

        
        public void AdaugaTranzactie(Tranzactie tranzactie)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();

           
            int maxId = tranzactii.Count > 0 ? tranzactii.Max(t => t.Id) : 0;
            if (tranzactie.Id <= maxId)
            {
                
                tranzactie = new Tranzactie(
                    tranzactie.Valuta,
                    tranzactie.Suma,
                    tranzactie.DataTranzactie,
                    tranzactie.UserId,
                    tranzactie.Tip
                )
                { Id = maxId + 1 };
            }

            tranzactii.Add(tranzactie);
            SalveazaTranzactii(tranzactii);
        }



        public List<Tranzactie> GetTranzactiiUtilizator(int userId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            return tranzactii.Where(t => t.UserId == userId).ToList();
        }

        
        public List<Tranzactie> GetTranzactiiUtilizatorDupaTip(int userId, TipTranzactie tip)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            return tranzactii.Where(t => t.UserId == userId && t.Tip == tip).ToList();
        }

   
        public List<Tranzactie> GetTranzactiiUtilizatorPerioada(int userId, DateTime dataStart, DateTime dataEnd)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            return tranzactii.Where(t => t.UserId == userId &&
                                         t.DataTranzactie >= dataStart &&
                                         t.DataTranzactie <= dataEnd).ToList();
        }

       

        public bool ActualizeazaTranzactie(int tranzactieId, Tranzactie tranzactieActualizata)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            int index = tranzactii.FindIndex(t => t.Id == tranzactieId);

            if (index != -1)
            {   
                tranzactieActualizata.Id = tranzactieId;
                tranzactii[index] = tranzactieActualizata;
                
                SalveazaTranzactii(tranzactii);

                StergeTranzactie(tranzactieActualizata.Id);
                return true;
            }

            return false;
        }

      
        public bool StergeTranzactie(int tranzactieId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            int index = tranzactii.FindIndex(t => t.Id == tranzactieId);

            if (index != -1)
            {
                tranzactii.RemoveAt(index);
                SalveazaTranzactii(tranzactii);
                return true;
            }

            return false;
        }

 
        public double CalculeazaTotalVenituri(int userId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            double total = 0;
            
            foreach (var tranzactie in tranzactii.Where(t => t.UserId == userId && t.Tip == TipTranzactie.Venit))
            {
             
                double sumaInRON = SchimbValutar(tranzactie.Suma, tranzactie.Valuta.ToString(), "RON");
                total += sumaInRON;
            }
            
            return Math.Round(total, 2);
        }


        public double CalculeazaTotalCheltuieli(int userId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            double total = 0;
            
            foreach (var tranzactie in tranzactii.Where(t => t.UserId == userId && t.Tip == TipTranzactie.Cheltuiala))
            {
                
                double sumaInRON = SchimbValutar(tranzactie.Suma, tranzactie.Valuta.ToString(), "RON");
                total += sumaInRON;
            }
            
            return Math.Round(total, 2);

        }
        public double SchimbValutar(double suma, string valutaSursa, string valutaDestinatie)
        {
            Dictionary<string, double> rateValutare = RateValutare.Rate;
        
            double sumaInRON = suma * rateValutare[valutaSursa]; 
            double result = sumaInRON / rateValutare[valutaDestinatie]; 
            
            return Math.Round(result, 2);
        }

        private List<Tranzactie> IncarcaTranzactii()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions();
                options.Converters.Add(new JsonStringEnumConverter());
                return JsonSerializer.Deserialize<List<Tranzactie>>(jsonString, options) ?? new List<Tranzactie>();
            }
            return new List<Tranzactie>();
        }



        private void SalveazaTranzactii(List<Tranzactie> tranzactii)
        {
            string jsonString = JsonSerializer.Serialize(tranzactii, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
        

        public double CalculeazaVenituriLunare(int userId)
        {
            double total = 0;
            var tranzactiiLunare = GetTranzactiiUtilizatorDupaTip(userId, TipTranzactie.Venit)
                                  .Where(t => t.DataTranzactie.Month == DateTime.Now.Month);
            
            foreach (var tranzactie in tranzactiiLunare)
            {
                double sumaInRON = SchimbValutar(tranzactie.Suma, tranzactie.Valuta.ToString(), "RON");
                total += sumaInRON;
            }
            
            return Math.Round(total, 2);
        }

        public double CalculeazaVenituriZilnice(int userId)
        {
            double total = 0;
            var tranzactiiZilnice = GetTranzactiiUtilizatorDupaTip(userId, TipTranzactie.Venit)
                                   .Where(t => t.DataTranzactie.Date == DateTime.Now.Date);
            
            foreach (var tranzactie in tranzactiiZilnice)
            {
                
                double sumaInRON = SchimbValutar(tranzactie.Suma, tranzactie.Valuta.ToString(), "RON");
                total += sumaInRON;
            }
            
            return Math.Round(total, 2);
        }

        public double CalculeazaCheltuieliLunare(int userId)
        {
            double total = 0;
            var tranzactiiLunare = GetTranzactiiUtilizatorDupaTip(userId, TipTranzactie.Cheltuiala)
                                  .Where(t => t.DataTranzactie.Month == DateTime.Now.Month);
            
            foreach (var tranzactie in tranzactiiLunare)
            {
              
                double sumaInRON = SchimbValutar(tranzactie.Suma, tranzactie.Valuta.ToString(), "RON");
                total += sumaInRON;
            }
            
            return Math.Round(total, 2);
        }

        public double CalculeazaCheltuieliZilnice(int userId)
        {
            double total = 0;
            var tranzactiiZilnice = GetTranzactiiUtilizatorDupaTip(userId, TipTranzactie.Cheltuiala)
                                   .Where(t => t.DataTranzactie.Date == DateTime.Now.Date);
            
            foreach (var tranzactie in tranzactiiZilnice)
            {
                double sumaInRON = SchimbValutar(tranzactie.Suma, tranzactie.Valuta.ToString(), "RON");
                total += sumaInRON;
            }
            
            return Math.Round(total, 2);
        }
    }
}
