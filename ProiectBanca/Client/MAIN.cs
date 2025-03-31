using System;
using System.Windows.Forms;
using Modele.ClaseModele;

namespace ProiectBanca
{
    public partial class MAIN : Form
    {
        private AdminUser adminUser;
        private AdminTranzactii adminTranzactii;

        public MAIN(AdminUser adminUser)
        {
            InitializeComponent();
            this.adminUser = adminUser;
            this.adminTranzactii = new AdminTranzactii();

            // Obține utilizatorul curent și afișează numele acestuia
            User currentUser = adminUser.GetUserCurent();
            if (currentUser != null)
            {
                label5.Text = $"Bun venit, {currentUser.Nume}!";
                ActualizeazaInformatii(currentUser.Id);
            }
            else
            {
                MessageBox.Show("Nu s-a putut obține utilizatorul curent.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            User currentUser = adminUser.GetUserCurent();
            if (currentUser != null)
            {
                ActualizeazaInformatii(currentUser.Id);
            }
        }

        private void ActualizeazaInformatii(int userId)
        {
            try
            {
                // Calculează veniturile și cheltuielile utilizatorului
                double totalVenituri = adminTranzactii.CalculeazaTotalVenituri(userId);
                double totalCheltuieli = adminTranzactii.CalculeazaTotalCheltuieli(userId);

                // Actualizează label-urile cu valorile calculate
                Totalv.Text = $"Total Venituri:";
                venituri.Text = $"{totalVenituri:C}";
                cheltuieli.Text = $"{totalCheltuieli:C}";
                Totalc.Text = $"Total Cheltuieli:";

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea informațiilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
