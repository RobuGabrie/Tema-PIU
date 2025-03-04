using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdministrareDate.Administrari;
using Modele.ClaseModele;

namespace ProiectBanca
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AdministrareVenituri administrareVenituri = new AdministrareVenituri();
            AdministrareCheltuieli administrareCheltuieli = new AdministrareCheltuieli();

            bool iesire = false;
            while (!iesire)
            {
                Console.WriteLine("Alegeti o optiune:");
                Console.WriteLine("1. Adauga Venit");
                Console.WriteLine("2. Vizualizeaza Toate Veniturile");
                Console.WriteLine("3. Vizualizeaza Veniturile pentru Astazi");
                Console.WriteLine("4. Vizualizeaza Veniturile pentru Luna aceasta");
                Console.WriteLine("5. Vizualizeaza Veniturile pentru Anul acesta");
                Console.WriteLine("6. Vizualizeaza Veniturile dupa Valuta");
                Console.WriteLine("7. Adauga Cheltuiala");
                Console.WriteLine("8. Vizualizeaza Toate Cheltuielile");
                Console.WriteLine("9. Vizualizeaza Cheltuielile pentru Astazi");
                Console.WriteLine("10. Vizualizeaza Cheltuielile pentru Luna aceasta");
                Console.WriteLine("11. Vizualizeaza Cheltuielile pentru Anul acesta");
                Console.WriteLine("0. Iesi");
                Console.Write("Introduceti alegerea: ");
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        administrareVenituri.AdaugaVenit(administrareVenituri.CitireVenitTastatura());
                        break;
                    case "2":
                        List<Venit> venituri = administrareVenituri.GetToateVenituri();
                        Console.WriteLine("Venituri: ");
                        foreach (Venit venit in venituri)
                        {
                            Console.WriteLine(venit.Info());
                        }
                        break;
                    case "3":
                        List<Venit> venituriZi = administrareVenituri.GetVenituriZi();
                        Console.WriteLine("Venituri pentru astazi: ");
                        foreach (Venit venit in venituriZi)
                        {
                            Console.WriteLine(venit.Info());
                        }
                        break;
                    case "4":
                        List<Venit> venituriLuna = administrareVenituri.GetVenituriLuna();
                        Console.WriteLine("Venituri pentru luna aceasta: ");
                        foreach (Venit venit in venituriLuna)
                        {
                            Console.WriteLine(venit.Info());
                        }
                        break;
                    case "5":
                        List<Venit> venituriAn = administrareVenituri.GetVenituriAn();
                        Console.WriteLine("Venituri pentru anul acesta: ");
                        foreach (Venit venit in venituriAn)
                        {
                            Console.WriteLine(venit.Info());
                        }
                        break;
                    case "6":
                        Console.Write("Introduceti valuta: ");
                        string valuta = Console.ReadLine();
                        List<Venit> venituriValuta = administrareVenituri.GetVenituriValuta(valuta);
                        foreach (Venit venit in venituriValuta)
                        {
                            Console.WriteLine(venit.Info());
                        }
                        break;
                    case "7":
                        administrareCheltuieli.AdaugaCheltuiala(administrareCheltuieli.CitireCheltuialaTastatura());
                        break;
                    case "8":
                        List<Cheltuiala> cheltuieli = administrareCheltuieli.GetToateCheltuielile();
                        Console.WriteLine("Cheltuieli: ");
                        foreach (Cheltuiala cheltuiala in cheltuieli)
                        {
                            Console.WriteLine(cheltuiala.Info());
                        }
                        break;
                    case "9":
                        List<Cheltuiala> cheltuieliZi = administrareCheltuieli.GetCheltuieliZi();
                        Console.WriteLine("Cheltuieli pentru astazi: ");
                        foreach (Cheltuiala cheltuiala in cheltuieliZi)
                        {
                            Console.WriteLine(cheltuiala.Info());
                        }
                        break;
                    case "10":
                        List<Cheltuiala> cheltuieliLuna = administrareCheltuieli.GetCheltuieliLuna();
                        Console.WriteLine("Cheltuieli pentru luna aceasta: ");
                        foreach (Cheltuiala cheltuiala in cheltuieliLuna)
                        {
                            Console.WriteLine(cheltuiala.Info());
                        }
                        break;
                    case "11":
                        List<Cheltuiala> cheltuieliAn = administrareCheltuieli.GetCheltuieliAn();
                        Console.WriteLine("Cheltuieli pentru anul acesta: ");
                        foreach (Cheltuiala cheltuiala in cheltuieliAn)
                        {
                            Console.WriteLine(cheltuiala.Info());
                        }
                        break;
                    case "0":
                        iesire = true;
                        break;
                    default:
                        Console.WriteLine("Alegere invalida. Incercati din nou.");
                        break;
                }
            }

            // Lansati aplicatia Windows Forms
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SIGN_IN());
        }
    }
}
