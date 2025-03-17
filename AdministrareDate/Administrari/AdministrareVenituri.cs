using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Modele.ClaseModele;

namespace AdministrareDate.Administrari
{
    public class AdministrareVenituri_FisierText
    {
        private const int NR_MAX_VENITURI = 1000;
        private string numeFisier;

        public AdministrareVenituri_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;

            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaVenit(Venit venit)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(venit.ConversieLaSir_PentruFisier());
            }
        }

        public List<Venit> GetToateVeniturile()
        {
            List<Venit> venituri = new List<Venit>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    venituri.Add(new Venit(linieFisier));
                }
            }

            return venituri;
        }

        public List<Venit> GetVenituriZi()
        {
            DateTime astazi = DateTime.Today;
            return GetToateVeniturile().Where(v => v.DataTranzactie.Date == astazi).ToList();
        }

        public List<Venit> GetVenituriLuna()
        {
            DateTime lunaAstazi = DateTime.Today;
            return GetToateVeniturile().Where(v => v.DataTranzactie.Month == lunaAstazi.Month).ToList();
        }

        public List<Venit> GetVenituriAn()
        {
            DateTime anAstazi = DateTime.Today;
            return GetToateVeniturile().Where(v => v.DataTranzactie.Year == anAstazi.Year).ToList();
        }

        public List<Venit> GetVenituriValuta(string valuta)
        {
            return GetToateVeniturile().Where(v => v.Valuta == valuta).ToList();
        }
        public List<Venit> GetToateVeniturileInValuta(string valutaConversie)
        {
            List<Venit> venituri = GetToateVeniturile();
            List<Venit> venituriInValuta = new List<Venit>();

            foreach (Venit venit in venituri)
            {
                double sumaInValuta = venit.Suma;
                if (venit.Valuta != valutaConversie)
                {
                    sumaInValuta = ConversieValutara(venit.Valuta, valutaConversie, venit.Suma);
                }

                venituriInValuta.Add(new Venit(valutaConversie, sumaInValuta, venit.DataTranzactie, venit.Descriere, venit.Categorie));
            }

            return venituriInValuta;
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

        public List<Venit>[] GetVenituriOrdine()
        { 
            List<Venit> venituri = GetToateVeniturile();
            List<Venit>[] venituriGrupate = new List<Venit>[26];
            for (int i = 0; i < 26; i++)
            {
                venituriGrupate[i] = new List<Venit>();
            }
            foreach (Venit v in venituri)
            {
                int litera = v.Descriere[0] - 'A';
                if (litera >= 0 && litera < 26)
                {
                    venituriGrupate[litera].Add(v);
                }

            }

            //List<Venit> venituriOrdonate = new List<Venit>();
            //for (int i = 0; i < 26; i++)
            //{
            //    venituriGrupate[i] = venituriGrupate[i].OrderBy(v => v.Descriere).ToList();
            //    venituriOrdonate.AddRange(venituriGrupate[i]);
            //}
            //using (StreamWriter streamWriter = new StreamWriter(numeFisier, false))
            //{
            //    foreach (Venit v in venituriOrdonate)
            //    {
            //        streamWriter.WriteLine(v.ConversieLaSir_PentruFisier());
            //    }
            //}
            return venituriGrupate;
        }
        
}
    }