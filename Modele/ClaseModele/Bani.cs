using System;
using System.Collections.Generic;

namespace Modele.ClaseModele
{
    public class Bani
    {
        public string Valuta { get; set; }
        public double Suma { get; set; }

        public Bani(string valuta, double suma)
        {
            Valuta = valuta;
            Suma = suma;
        }

        public Bani() : this("NEDEFINITA", 0) { }

        public override string ToString()
        {
            return $"Valuta: {Valuta}, Suma: {Suma}";
        }
    }
}
