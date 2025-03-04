using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ClaseModele;

namespace AdministrareDate.Administrari
{
    public class AdministrareCheltuieli
    {
        private List<Cheltuiala> ToateCheltuielile = [];
        public List<Cheltuiala> GetToateCheltuielile()
        {
            return ToateCheltuielile;
        }
        public Cheltuiala CitireCheltuialaTastatura()
        {
            Console.Write("Introduceti valuta: ");
            string valuta = Console.ReadLine();

            Console.Write("Introduceti suma: ");
            double suma = Convert.ToDouble(Console.ReadLine());

            DateTime data = DateTime.Now;

            Console.Write("Introduceti descrierea: ");
            string descriere = Console.ReadLine();

            Console.Write("Introduceti categoria: ");
            string categorie = Console.ReadLine();

            return (new Cheltuiala(valuta, suma, data, descriere, categorie));
        }
        public void AdaugaCheltuiala(Cheltuiala cheltuiala)
        {
            if (!ToateCheltuielile.Contains(cheltuiala))
            {
                ToateCheltuielile.Add(cheltuiala);
            }
        }
        public List<Cheltuiala> GetCheltuieliZi()
        {
            DateTime astazi = DateTime.Today;
            return [.. ToateCheltuielile.Where(c => c.DataTranzactie.Date == astazi)];
        }
        public List<Cheltuiala> GetCheltuieliLuna()
        {
            DateTime lunaAstazi = DateTime.Today;
            return [.. ToateCheltuielile.Where(c => c.DataTranzactie.Month == lunaAstazi.Month)];
        }
        public List<Cheltuiala> GetCheltuieliAn()
        {
            DateTime anAstazi = DateTime.Today;
            return [.. ToateCheltuielile.Where(c => c.DataTranzactie.Year == anAstazi.Year)];
        }
        public List<Cheltuiala> GetCheltuieliValuta(string valuta)
        {
            return ToateCheltuielile.Where(v => v.Valuta == valuta).ToList();
        }
    }
}
