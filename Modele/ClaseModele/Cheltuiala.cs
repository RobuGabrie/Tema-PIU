using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ClaseModele
    {
        public class Cheltuiala : Tranzactie
        {
            public string Descriere { get; set; }
            public string Categorie { get; set; }

           

        public Cheltuiala(string valuta, double suma, DateTime dataTranzactie, string descriere, string categorie) : base(valuta, suma, dataTranzactie)
            {
                Descriere = descriere;
                Categorie = categorie;
            }
            public Cheltuiala()
            {
                Descriere = "";
                Categorie = "";
            }
        public override string Info()
        {
            return $"CHELTUIALA: {base.Info()}, Descriere: {Descriere}, Categorie: {Categorie}";
        }
    }
    }

