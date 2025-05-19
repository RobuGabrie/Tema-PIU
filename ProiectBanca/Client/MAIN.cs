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
            panel2.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panel2.Controls.Add(page); 
            panel2.BringToFront(); 
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

        private void Button1_Click(object sender, EventArgs e) 
        {
          
            LoadPage(new VenituriPage(adminUser));
        }

        private void Button2_Click(object sender, EventArgs e) 
        {
            LoadPage(new CheltuieliPage(adminUser));
        }

        private void Button3_Click(object sender, EventArgs e) 
        {
            LoadPage(new SchimbValutarPage());
        }
    }
}
