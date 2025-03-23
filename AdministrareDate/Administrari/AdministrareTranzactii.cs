using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

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

        private List<Tranzactie> IncarcaTranzactii()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Tranzactie>>(jsonString) ?? new List<Tranzactie>();
            }
            return new List<Tranzactie>();
        }

        // Salvează lista de tranzacții în fișier
        private void SalveazaTranzactii(List<Tranzactie> tranzactii)
        {
            string jsonString = JsonSerializer.Serialize(tranzactii, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
