using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ClaseModele
{
    public class Tranzactie : Bani
    {
        public DateTime DataTranzactie { get; set; }

        private static int nextId = 1;
        public int Id { get; private set; }

        public Tranzactie(string valuta, double suma, DateTime dataTranzactie) : base(valuta, suma) 
        {
            DataTranzactie = dataTranzactie;
            Id  = nextId++;
        }
        public Tranzactie()
        {
            DataTranzactie = DateTime.Now;
            Id = nextId++;
        }

        public override string Info()
        {
            return $"Id: {Id}, {base.Info()}, Data tranzactie: {DataTranzactie}";
        }
    }
}
