using System;
using System.Collections.Generic;
using System.Linq;
using Modele.ClaseModele;

namespace AdministrareDate.Administrari
{
    public class AdministrareVenituri
    {
        private List<Venit> ToateVeniturile = new List<Venit>();


        public List<Venit> GetToateVenituri()
        {
            return ToateVeniturile;
        }

        public Venit CitireVenitTastatura()
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

            return(new Venit(valuta, suma, data, descriere, categorie));
        }


        public void AdaugaVenit(Venit venit)
        {
            if (!ToateVeniturile.Contains(venit))
            {
                ToateVeniturile.Add(venit);
            }
        }
        public List<Venit> GetVenituriZi()
        {
            DateTime astazi = DateTime.Today;
            return ToateVeniturile.Where(v => v.DataTranzactie.Date == astazi).ToList();
        }
        public List<Venit> GetVenituriLuna()
        {
            DateTime lunaAstazi = DateTime.Today;
            return ToateVeniturile.Where(v => v.DataTranzactie.Month == lunaAstazi.Month).ToList();
        }
        public List<Venit> GetVenituriAn()
        {
            DateTime anAstazi = DateTime.Today;
            return ToateVeniturile.Where(v => v.DataTranzactie.Year == anAstazi.Year).ToList();
        }
        public List<Venit> GetVenituriValuta(string valuta)
        {
            return ToateVeniturile.Where(v => v.Valuta == valuta).ToList();
        }
    }
}
