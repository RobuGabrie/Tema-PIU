using System;
using Modele.ClaseModele;
using System.Collections.Generic;

class Program
{
    static AdminUser adminUser = new AdminUser();
    static AdminTranzactii adminTranzactii = new AdminTranzactii();

    static void Main(string[] args)
    {
        bool continuaProgram = true;

        Console.WriteLine("=== Aplicatie de Gestionare a Finantelor Personale ===");

        while (continuaProgram)
        {
            if (adminUser.EsteAutentificat())
            {
                AfiseazaMeniuUtilizatorAutentificat();
            }
            else
            {
                AfiseazaMeniuPrincipal();
            }

            string optiune = Console.ReadLine();
            continuaProgram = ProcesareOptiune(optiune);
        }

        Console.WriteLine("Aplicatia s-a inchis. La revedere!");
    }

    static void AfiseazaMeniuPrincipal()
    {
        Console.WriteLine("\n=== Meniu Principal ===");
        Console.WriteLine("1. Inregistrare");
        Console.WriteLine("2. Autentificare");
        Console.WriteLine("0. Iesire");
        Console.Write("Alegeti o optiune: ");
    }

    static void AfiseazaMeniuUtilizatorAutentificat()
    {
        User userCurent = adminUser.GetUserCurent();
        Console.WriteLine($"\n=== Bine ati venit, {userCurent.Nume}! ===");
        Console.WriteLine("1. Adauga tranzactie");
        Console.WriteLine("2. Vizualizeaza toate tranzactiile");
        Console.WriteLine("3. Vizualizeaza veniturile");
        Console.WriteLine("4. Vizualizeaza cheltuielile");
        Console.WriteLine("5. Vizualizeaza balanta");
        Console.WriteLine("6. Sterge o tranzactie");
        Console.WriteLine("7. Deconectare");
        Console.WriteLine("0. Iesire");
        Console.Write("Alegeti o optiune: ");
    }

    static bool ProcesareOptiune(string optiune)
    {
        if (adminUser.EsteAutentificat())
        {
            return ProcesareOptiuneUtilizatorAutentificat(optiune);
        }
        else
        {
            return ProcesareOptiuneMeniuPrincipal(optiune);
        }
    }

    static bool ProcesareOptiuneMeniuPrincipal(string optiune)
    {
        switch (optiune)
        {
            case "1":
                InregistrareUtilizator();
                return true;
            case "2":
                AutentificareUtilizator();
                return true;
            case "0":
                return false;
            default:
                Console.WriteLine("Optiune invalida. Incercati din nou.");
                return true;
        }
    }

    static bool ProcesareOptiuneUtilizatorAutentificat(string optiune)
    {
        switch (optiune)
        {
            case "1":
                AdaugaTranzactie();
                return true;
            case "2":
                VizualizeazaToateTranzactiile();
                return true;
            case "3":
                VizualizeazaVenituri();
                return true;
            case "4":
                VizualizeazaCheltuieli();
                return true;
            case "5":
                VizualizeazaBalanta();
                return true;
            case "6":
                StergeTranzactie();
                return true;
            case "7":
                adminUser.Deconectare();
                Console.WriteLine("V-ati deconectat cu succes!");
                return true;
            case "0":
                return false;
            default:
                Console.WriteLine("Optiune invalida. Incercati din nou.");
                return true;
        }
    }

    static void InregistrareUtilizator()
    {
        Console.WriteLine("\n=== Inregistrare Utilizator ===");

        Console.Write("Nume: ");
        string nume = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Parola: ");
        string parola = Console.ReadLine();

        if (adminUser.Inregistrare(nume, email, parola))
        {
            Console.WriteLine("Inregistrare reusita! Acum sunteti autentificat.");
        }
        else
        {
            Console.WriteLine("Inregistrare esuata. Emailul poate fi deja utilizat.");
        }
    }

    static void AutentificareUtilizator()
    {
        Console.WriteLine("\n=== Autentificare ===");

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Parola: ");
        string parola = Console.ReadLine();

        if (adminUser.Autentificare(email, parola))
        {
            Console.WriteLine("Autentificare reusita!");
        }
        else
        {
            Console.WriteLine("Autentificare esuata. Verificati emailul si parola.");
        }
    }

    static void AdaugaTranzactie()
    {
        Console.WriteLine("\n=== Adaugare Tranzactie ===");

        Console.Write("Valuta (ex: RON, EUR, USD): ");
        string valuta = Console.ReadLine();

        double suma = 0;
        bool sumaValida = false;
        while (!sumaValida)
        {
            Console.Write("Suma: ");
            sumaValida = double.TryParse(Console.ReadLine(), out suma);
            if (!sumaValida)
            {
                Console.WriteLine("Suma invalida. Introduceti un numar valid.");
            }
        }

        Console.WriteLine("Tip tranzactie:");
        Console.WriteLine("1. Venit");
        Console.WriteLine("2. Cheltuiala");

        TipTranzactie tip = TipTranzactie.Venit;
        bool tipValid = false;
        while (!tipValid)
        {
            Console.Write("Alegeti tipul (1 sau 2): ");
            string tipString = Console.ReadLine();
            if (tipString == "1")
            {
                tip = TipTranzactie.Venit;
                tipValid = true;
            }
            else if (tipString == "2")
            {
                tip = TipTranzactie.Cheltuiala;
                tipValid = true;
            }
            else
            {
                Console.WriteLine("Optiune invalida. Alegeti 1 pentru Venit sau 2 pentru Cheltuiala.");
            }
        }

        User userCurent = adminUser.GetUserCurent();
        Tranzactie tranzactie = new Tranzactie(valuta, suma, DateTime.Now, userCurent.Id, tip);
        adminTranzactii.AdaugaTranzactie(tranzactie);

        Console.WriteLine("Tranzactie adaugata cu succes!");
    }

    static void VizualizeazaToateTranzactiile()
    {
        User userCurent = adminUser.GetUserCurent();
        List<Tranzactie> tranzactii = adminTranzactii.GetTranzactiiUtilizator(userCurent.Id);

        Console.WriteLine("\n=== Toate Tranzactiile ===");

        if (tranzactii.Count == 0)
        {
            Console.WriteLine("Nu aveti nicio tranzactie inregistrata.");
            return;
        }

        foreach (var tranzactie in tranzactii)
        {
            Console.WriteLine(tranzactie);
        }
    }

    static void VizualizeazaVenituri()
    {
        User userCurent = adminUser.GetUserCurent();
        List<Tranzactie> venituri = adminTranzactii.GetTranzactiiUtilizatorDupaTip(userCurent.Id, TipTranzactie.Venit);

        Console.WriteLine("\n=== Venituri ===");

        if (venituri.Count == 0)
        {
            Console.WriteLine("Nu aveti niciun venit inregistrat.");
            return;
        }

        foreach (var venit in venituri)
        {
            Console.WriteLine(venit);
        }

        double totalVenituri = adminTranzactii.CalculeazaTotalVenituri(userCurent.Id);
        Console.WriteLine($"\nTotal venituri: {totalVenituri}");
    }

    static void VizualizeazaCheltuieli()
    {
        User userCurent = adminUser.GetUserCurent();
        List<Tranzactie> cheltuieli = adminTranzactii.GetTranzactiiUtilizatorDupaTip(userCurent.Id, TipTranzactie.Cheltuiala);

        Console.WriteLine("\n=== Cheltuieli ===");

        if (cheltuieli.Count == 0)
        {
            Console.WriteLine("Nu aveti nicio cheltuiala inregistrata.");
            return;
        }

        foreach (var cheltuiala in cheltuieli)
        {
            Console.WriteLine(cheltuiala);
        }

        double totalCheltuieli = adminTranzactii.CalculeazaTotalCheltuieli(userCurent.Id);
        Console.WriteLine($"\nTotal cheltuieli: {totalCheltuieli}");
    }

    static void VizualizeazaBalanta()
    {
        User userCurent = adminUser.GetUserCurent();
        double totalVenituri = adminTranzactii.CalculeazaTotalVenituri(userCurent.Id);
        double totalCheltuieli = adminTranzactii.CalculeazaTotalCheltuieli(userCurent.Id);
        

        Console.WriteLine("\n=== Balanta Financiara ===");
        Console.WriteLine($"Total venituri: {totalVenituri}");
        Console.WriteLine($"Total cheltuieli: {totalCheltuieli}");

    }

    static void StergeTranzactie()
    {
        VizualizeazaToateTranzactiile();

        Console.Write("\nIntroduceti ID-ul tranzactiei pe care doriti sa o stergeti (0 pentru anulare): ");
        if (int.TryParse(Console.ReadLine(), out int id) && id > 0)
        {
            if (adminTranzactii.StergeTranzactie(id))
            {
                Console.WriteLine("Tranzactie stearsa cu succes!");
            }
            else
            {
                Console.WriteLine("Nu s-a putut sterge tranzactia. Verificati ID-ul.");
            }
        }
        else if (id != 0)
        {
            Console.WriteLine("ID invalid.");
        }
    }
}
