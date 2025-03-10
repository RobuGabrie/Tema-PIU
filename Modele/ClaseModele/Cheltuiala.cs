public class Cheltuiala
{
    public string Valuta { get; set; }
    public double Suma { get; set; }
    public DateTime DataTranzactie { get; set; }
    public string Descriere { get; set; }
    public string Categorie { get; set; }

    public Cheltuiala(string valuta, double suma, DateTime data, string descriere, string categorie)
    {
        Valuta = valuta;
        Suma = suma;
        DataTranzactie = data;
        Descriere = descriere;
        Categorie = categorie;
    }

    
    public Cheltuiala(string linieFisier)
    {
        string[] componente = linieFisier.Split(';');
        if (componente.Length == 5) // Verifică dacă avem toate cele 5 componente
        {
            Valuta = componente[0];
            Suma = Convert.ToDouble(componente[1]);
            DataTranzactie = DateTime.ParseExact(componente[2], "yyyy-MM-dd", null);
            Descriere = componente[3];
            Categorie = componente[4];
        }
        else
        {
            throw new FormatException("Formatul liniei din fișier este incorect.");
        }
    }

    public string ConversieLaSir_PentruFisier()
    {
        return $"{Valuta};{Suma};{DataTranzactie.ToString("yyyy-MM-dd")};{Descriere};{Categorie}";
    }
}
