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

            // Load DashboardPage into panel2 by default
            var dashboardPage = new DashboardPage();
            dashboardPage.UpdateData(
                adminTranzactii.CalculeazaTotalVenituri(currentUser.Id),
                adminTranzactii.CalculeazaTotalCheltuieli(currentUser.Id),
                adminTranzactii.CalculeazaVenituriLunare(currentUser.Id),
                adminTranzactii.CalculeazaVenituriZilnice(currentUser.Id),
                adminTranzactii.CalculeazaCheltuieliLunare(currentUser.Id),
                adminTranzactii.CalculeazaCheltuieliZilnice(currentUser.Id)
            );
            LoadPage(dashboardPage);
        }

        private void ActualizeazaInformatii(int userId)
        {
            try
            {
                // Calculează veniturile și cheltuielile utilizatorului
                double totalVenituri = adminTranzactii.CalculeazaTotalVenituri(userId);
                double totalCheltuieli = adminTranzactii.CalculeazaTotalCheltuieli(userId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea informațiilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPage(UserControl page)
        {
            panel2.Controls.Clear(); // Clear the panel
            page.Dock = DockStyle.Fill; // Set the new page to fill the panel
            panel2.Controls.Add(page); // Add the new page to the panel
            panel2.BringToFront(); // Ensure the panel is brought to the front
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            var currentUser = adminUser.GetUserCurent();
            if (currentUser != null)
            {
                var dashboardPage = new DashboardPage();
                dashboardPage.UpdateData(
                    adminTranzactii.CalculeazaTotalVenituri(currentUser.Id),
                    adminTranzactii.CalculeazaTotalCheltuieli(currentUser.Id),
                    adminTranzactii.CalculeazaVenituriLunare(currentUser.Id),
                    adminTranzactii.CalculeazaVenituriZilnice(currentUser.Id),
                    adminTranzactii.CalculeazaCheltuieliLunare(currentUser.Id),
                    adminTranzactii.CalculeazaCheltuieliZilnice(currentUser.Id)
                );
                LoadPage(dashboardPage);
            }
            else
            {
                MessageBox.Show("Nu s-a putut obține utilizatorul curent.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e) // Venituri
        {
            // Pass the current adminUser instance to VenituriPage
            LoadPage(new VenituriPage(adminUser));
        }

        private void Button2_Click(object sender, EventArgs e) // Cheltuieli
        {
            LoadPage(new CheltuieliPage());
        }

        private void Button3_Click(object sender, EventArgs e) // Schimb Valutar
        {
            LoadPage(new SchimbValutarPage());
        }
    }
}
