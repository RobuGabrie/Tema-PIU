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

        bool rulare = true;
        while (rulare)
        {
            Console.Clear();
            Console.WriteLine("===== MENIU =====");
            Console.WriteLine("1. Afisare toate veniturile");
            Console.WriteLine("2. Afisare venituri in ordine alfabetica");
            Console.WriteLine("3. Iesire");
            Console.Write("\nAlegeti o optiune: ");

            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    AfiseazaVenituri(administrareVenituri.GetToateVeniturile(), "Toate Veniturile");
                    break;
                case "2":
                    List<Venit>[] venituriOrdine = administrareVenituri.GetVenituriOrdine();

                    for (int i = 0; i < venituriOrdine.Length; i++)
                    {
                        char litera = (char)('a' + i);
                        Console.WriteLine($"Venituri care incep cu litera '{litera}' ");

                        if (venituriOrdine[i].Count > 0)
                        {
                            foreach (Venit v in venituriOrdine[i])
                            {
                                Console.WriteLine(v.ConversieLaSir_PentruFisier());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu exista venituri pentru aceasta litera.");
                        }

                        Console.WriteLine(new string('-', 50));
                    }
                    Console.ReadKey();

                    break;
                case "3":
                    rulare = false;
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Apasati orice tasta pentru a continua...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void AfiseazaVenituri(List<Venit> venituri, string titlu)
    {
        Console.Clear();
        Console.WriteLine($"===== {titlu} =====");

        if (venituri.Count == 0)
        {
            Console.WriteLine("Nu exista inregistrari.");
        }
        else
        {
            foreach (Venit v in venituri)
            {
                Console.WriteLine(v.ConversieLaSir_PentruFisier());
            }
        }

        Console.WriteLine(new string('-', 50));
        Console.ReadKey();
    }





    //Application.EnableVisualStyles();
    //Application.SetCompatibleTextRenderingDefault(false);
    //Application.Run(new SIGN_IN());
}

