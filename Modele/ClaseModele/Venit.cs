    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ClaseModele
{
    public class Venit : Tranzactie
    {
        public string Descriere { get; set; }
        public string Categorie { get; set; }

       


        public Venit(string valuta, double suma, DateTime dataTranzactie, string descriere, string categorie) : base(valuta, suma, dataTranzactie)
        {
            Descriere = descriere;
            Categorie = categorie;
        }
        public Venit()
        {
            Descriere = "";
            Categorie = "";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return $"{Valuta};{Suma};{DataTranzactie.ToString("yyyy-MM-dd")};{Descriere};{Categorie}";
        }

        public Venit(string linieFisier)
        {
            string[] componente = linieFisier.Split(';');
            if (componente.Length == 5) // Verifică dacă avem toate cele 5 componente
            {
                Valuta = componente[0];
                Suma = Convert.ToDouble(componente[1]);
                DataTranzactie = DateTime.ParseExact(componente[2], "yyyy-MM-dd", null);
                Descriere = componente[3];
                Categorie = componente[4];
            }
            else
            {
                throw new FormatException("Formatul liniei din fișier este incorect.");
            }
        }

    }
}
