using System;

namespace Modele.ClaseModele
{
    public enum TipTranzactie
    {
        Venit,
        Cheltuiala
    }

    public class Tranzactie : Bani
    {
        public int Id { get; set; }  
        public DateTime DataTranzactie { get; set; }
        public int UserId { get; set; }
        public TipTranzactie Tip { get; set; }

        public Tranzactie(string valuta, double suma, DateTime dataTranzactie, int userId, TipTranzactie tip) : base(valuta, suma)
        {
            Id = 0;  
            DataTranzactie = dataTranzactie;
            UserId = userId;
            Tip = tip;
        }

        public override string ToString()
        {
            return $"Id: {Id}, {base.ToString()}, Tip: {Tip}, Data tranzactie: {DataTranzactie}, UserId: {UserId}";
        }
    }
}
