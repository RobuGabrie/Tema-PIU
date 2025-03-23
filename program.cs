
using System;
using System.Windows.Forms;

namespace ProiectBanca
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SIGN_IN());
        }
    }
}
