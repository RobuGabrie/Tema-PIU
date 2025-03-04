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
    }
}
