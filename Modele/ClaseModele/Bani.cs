using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Bani()
        {
            Valuta = "NEDEFINITA";
            Suma = 0;
        }

        public virtual string Info()
        {
            return $"Valuta: {Valuta}, Suma: {Suma}";
        }

        public double ConversieValutara(string valutaConversie)
        {
            if (Valuta == "RON" && valutaConversie == "EUR")
            {
                return Suma / 4.87;
            }
            if (Valuta == "RON" && valutaConversie == "USD")
            {
                return Suma / 4.18;
            }
            if (Valuta == "EUR" && valutaConversie == "RON")
            {
                return Suma * 4.87;
            }
            if (Valuta == "EUR" && valutaConversie == "USD")
            {
                return Suma * 1.12;
            }
            if (Valuta == "USD" && valutaConversie == "RON")
            {
                return Suma * 4.18;
            }
            if (Valuta == "USD" && valutaConversie == "EUR")
            {
                return Suma / 1.12;
            }
            return Suma;
        }
    }
}

    
