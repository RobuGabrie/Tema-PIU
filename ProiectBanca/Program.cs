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
        static void Main() // Ensure the Main method is static and has the correct signature
        {
            Venit venit1 = new Venit("RON", 1000, DateTime.Now, "Salariu", "Job");
            Venit venit4 = new Venit("EUR", 1300, DateTime.Now, "Salariu", "Job");
            Venit venit5 = new Venit("EUR", 1500, DateTime.Now, "Salariu", "Job");
            Venit venit2 = new Venit("RON", 500, DateTime.Now.AddDays(-1), "Bonus", "Extra");
            Venit venit3 = new Venit("USD", 200, DateTime.Now.AddDays(-2), "Dividende", "Investitii");

            AdministrareCheltuieli adminCheltuieli = new AdministrareCheltuieli();
            Cheltuiala cheltuiala1 = new Cheltuiala("RON", 100, DateTime.Now, "Mancare", "Alimente");
            Cheltuiala cheltuiala2 = new Cheltuiala("RON", 50, DateTime.Now.AddDays(-1), "Mancare", "Alimente");
            Cheltuiala cheltuiala3 = new Cheltuiala("RON", 200, DateTime.Now.AddDays(-2), "Mancare", "Alimente");
            adminCheltuieli.AdaugaCheltuiala(cheltuiala1);
            adminCheltuieli.AdaugaCheltuiala(cheltuiala2);
            adminCheltuieli.AdaugaCheltuiala(cheltuiala3);
            List<Cheltuiala> cheltuieliZi = adminCheltuieli.GetCheltuieliZi();
            foreach (Cheltuiala cheltuiala in cheltuieliZi)
            {
                Console.WriteLine(cheltuiala.Info());
            }






            // Start the Windows Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SIGN_IN());
        }
    }
}
