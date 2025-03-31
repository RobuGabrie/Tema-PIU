using System;
using System.Collections.Generic;

namespace Modele.ClaseModele
{
    public enum Valuta
    {
        RON,
        EUR,
        USD,
        GBP,
        CHF,
        JPY,
        NEDEFINITA
    }


    public class Bani
    {
        public Valuta Valuta { get; set; }
        public double Suma { get; set; }

        public Bani(Valuta valuta, double suma)
        {
            Valuta = valuta;
            Suma = suma;
        }

        public Bani() : this(Valuta.NEDEFINITA, 0) { }

        public override string ToString()
        {
            return $"Valuta: {Valuta}, Suma: {Suma}";
        }
    }

}
