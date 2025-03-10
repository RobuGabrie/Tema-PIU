using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Modele.ClaseModele;

namespace AdministrareDate.Administrari
{
    public class AdministrareCheltuieli_FisierText
    {
        private const int NR_MAX_CHELTUIELI = 1000;
        private string numeFisier;

        public AdministrareCheltuieli_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
 
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        private double ConversieValutara(string valutaInitiala, string valutaConversie, double suma)
        {

            if (valutaInitiala == "RON" && valutaConversie == "EUR")
            {
                return suma / 4.87;
            }
            if (valutaInitiala == "RON" && valutaConversie == "USD")
            {
                return suma / 4.18;
            }
            if (valutaInitiala == "EUR" && valutaConversie == "RON")
            {
                return suma * 4.87;
            }
            if (valutaInitiala == "EUR" && valutaConversie == "USD")
            {
                return suma * 1.12;
            }
            if (valutaInitiala == "USD" && valutaConversie == "RON")
            {
                return suma * 4.18;
            }
            if (valutaInitiala == "USD" && valutaConversie == "EUR")
            {
                return suma / 1.12;
            }
            if (valutaInitiala == "GBP" && valutaConversie == "RON")
            {
                return suma * 5.30;
            }
            if (valutaInitiala == "GBP" && valutaConversie == "EUR")
            {
                return suma * 1.16; 
            }
            if (valutaInitiala == "GBP" && valutaConversie == "USD")
            {
                return suma * 1.31;
            }

            return suma;
        }

        public List<Cheltuiala> GetToateCheltuielileInValuta(string valutaConversie)
        {
            List<Cheltuiala> cheltuieli = GetToateCheltuielile();
            List<Cheltuiala> cheltuieliInValuta = new List<Cheltuiala>();

            foreach (Cheltuiala cheltuiala in cheltuieli)
            {
                double sumaInValuta = cheltuiala.Suma; 
                if (cheltuiala.Valuta != valutaConversie)
                {
                    sumaInValuta = ConversieValutara(cheltuiala.Valuta, valutaConversie, cheltuiala.Suma);
                }

                cheltuieliInValuta.Add(new Cheltuiala(valutaConversie, sumaInValuta, cheltuiala.DataTranzactie, cheltuiala.Descriere, cheltuiala.Categorie));
            }

            return cheltuieliInValuta;
        }
        public void AdaugaCheltuiala(Cheltuiala cheltuiala)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(cheltuiala.ConversieLaSir_PentruFisier());
            }
        }

        public List<Cheltuiala> GetToateCheltuielile()
        {
            List<Cheltuiala> cheltuieli = new List<Cheltuiala>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    cheltuieli.Add(new Cheltuiala(linieFisier));
                }
            }

            return cheltuieli;
        }

        public List<Cheltuiala> GetCheltuieliZi()
        {
            DateTime astazi = DateTime.Today;
            return GetToateCheltuielile().Where(c => c.DataTranzactie.Date == astazi).ToList();
        }

        public List<Cheltuiala> GetCheltuieliLuna()
        {
            DateTime lunaAstazi = DateTime.Today;
            return GetToateCheltuielile().Where(c => c.DataTranzactie.Month == lunaAstazi.Month).ToList();
        }

        public List<Cheltuiala> GetCheltuieliAn()
        {
            DateTime anAstazi = DateTime.Today;
            return GetToateCheltuielile().Where(c => c.DataTranzactie.Year == anAstazi.Year).ToList();
        }

        public List<Cheltuiala> GetCheltuieliValuta(string valuta)
        {
            return GetToateCheltuielile().Where(v => v.Valuta == valuta).ToList();
        }
    }
}
