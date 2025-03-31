using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Modele.ClaseModele;
using ProiectBanca;

namespace Program
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [STAThread]
        static void Main()
        {
            // Allocate a console for debugging purposes
            AllocConsole();

            // Initialize the Windows Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and run the main form
            Application.Run(new SIGN_IN());
        }
    }
}
