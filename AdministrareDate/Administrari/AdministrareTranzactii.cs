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
                tranzactii[index] = tranzactieActualizata;
                SalveazaTranzactii(tranzactii);
                return true;
            }

            return false;
        }

      
        public bool StergeTranzactie(int tranzactieId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            Tranzactie? tranzactie = tranzactii.FirstOrDefault(t => t.Id == tranzactieId);

            if (tranzactie != null)
            {
                tranzactii.Remove(tranzactie);
                SalveazaTranzactii(tranzactii);
                return true;
            }

            return false;
        }

 
        public double CalculeazaTotalVenituri(int userId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            return tranzactii.Where(t => t.UserId == userId && t.Tip == TipTranzactie.Venit)
                             .Sum(t => t.Suma);
        }


        public double CalculeazaTotalCheltuieli(int userId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();
            return tranzactii.Where(t => t.UserId == userId && t.Tip == TipTranzactie.Cheltuiala)
                             .Sum(t => t.Suma);

        }
        public double SchimbValutar(double suma, string valutaSursa, string valutaDestinatie)
        {
            Dictionary<string, double> rateValutare = RateValutare.Rate;
            if (!rateValutare.ContainsKey(valutaSursa) || !rateValutare.ContainsKey(valutaDestinatie))
            {
                throw new ArgumentException("Valuta specificată nu este suportată.");
            }

            double rataConversie = rateValutare[valutaDestinatie] / rateValutare[valutaSursa];
            return Math.Round(suma * rataConversie, 2);
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
        public Dictionary<Valuta, List<Tranzactie>> GetTranzactiiGrupatePerValuta(int userId)
        {
            List<Tranzactie> tranzactii = IncarcaTranzactii();

            List<Tranzactie> tranzactiiUtilizator = tranzactii.Where(t => t.UserId == userId).ToList();

            Dictionary<Valuta, List<Tranzactie>> tranzactiiPerValuta = new Dictionary<Valuta, List<Tranzactie>>();

            foreach (Tranzactie tranzactie in tranzactiiUtilizator)
            {
                Valuta valutaTranzactie = tranzactie.Valuta;

                if (!tranzactiiPerValuta.ContainsKey(valutaTranzactie))
                {
                    tranzactiiPerValuta[valutaTranzactie] = new List<Tranzactie>();
                }

                tranzactiiPerValuta[valutaTranzactie].Add(tranzactie);
            }

            return tranzactiiPerValuta;
        }



    }
}
