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
        //public static List<Venit> GetToateVeniturile()
        //{
        //    return ToateVeniturile;
        //}
        
        public override string Info()
        {
            return $"VENIT: {base.Info()},Descriere: {Descriere}, Categorie:{Categorie}";
        }

    }
}
