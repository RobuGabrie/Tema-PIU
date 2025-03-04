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
    }
}
