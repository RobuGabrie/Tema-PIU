using AdministrareDate.Administrari;
using Modele.ClaseModele;
using ProiectBanca;
using ProiectBanca.Client;

static class Program
{
    [STAThread]
    static void Main()
    {
        AdministrareVenituri_FisierText administrareVenituri = new AdministrareVenituri_FisierText("venituri.txt");
        AdministrareCheltuieli_FisierText administrareCheltuieli = new AdministrareCheltuieli_FisierText("cheltuieli.txt");

        Console.WriteLine("Toate Veniturile:");
        List<Venit> venituri = administrareVenituri.GetToateVeniturile();
        foreach (Venit v in venituri)
        {
            Console.WriteLine(v.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Venituri din Ziua Curentă:");
        List<Venit> venituriZi = administrareVenituri.GetVenituriZi();
        foreach (Venit v in venituriZi)
        {
            Console.WriteLine(v.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Venituri din Luna Curentă:");
        List<Venit> venituriLuna = administrareVenituri.GetVenituriLuna();
        foreach (Venit v in venituriLuna)
        {
            Console.WriteLine(v.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Venituri din Anul Curent:");
        List<Venit> venituriAn = administrareVenituri.GetVenituriAn();
        foreach (Venit v in venituriAn)
        {
            Console.WriteLine(v.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Toate Cheltuielile:");
        List<Cheltuiala> cheltuieli = administrareCheltuieli.GetToateCheltuielile();
        foreach (Cheltuiala c in cheltuieli)
        {
            Console.WriteLine(c.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Cheltuieli din Ziua Curentă:");
        List<Cheltuiala> cheltuieliZi = administrareCheltuieli.GetCheltuieliZi();
        foreach (Cheltuiala c in cheltuieliZi)
        {
            Console.WriteLine(c.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Cheltuieli din Luna Curentă:");
        List<Cheltuiala> cheltuieliLuna = administrareCheltuieli.GetCheltuieliLuna();
        foreach (Cheltuiala c in cheltuieliLuna)
        {
            Console.WriteLine(c.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Cheltuieli din Anul Curent:");
        List<Cheltuiala> cheltuieliAn = administrareCheltuieli.GetCheltuieliAn();
        foreach (Cheltuiala c in cheltuieliAn)
        {
            Console.WriteLine(c.ConversieLaSir_PentruFisier());
        }
        Console.WriteLine(new string('-', 50));

  
   
  

        Console.WriteLine("Venituri în EUR:");
        List<Venit> venituriInEUR = administrareVenituri.GetToateVeniturileInValuta("EUR");
        foreach (Venit v in venituriInEUR)
        {
            Console.WriteLine($"{v.ConversieLaSir_PentruFisier()}");
        }
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Cheltuieli în EUR:");
        List<Cheltuiala> cheltuieliInEUR = administrareCheltuieli.GetToateCheltuielileInValuta("EUR");
        foreach (Cheltuiala c in cheltuieliInEUR)
        {
            Console.WriteLine($"{c.ConversieLaSir_PentruFisier()}");
        }



        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new SIGN_IN());
    }
}
