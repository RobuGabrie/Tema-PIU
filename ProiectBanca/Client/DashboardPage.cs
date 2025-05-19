using System.Drawing;
using System.Windows.Forms;

namespace ProiectBanca
{
    public class DashboardPage : UserControl
    {
        private TableLayoutPanel mainLayout;
        private Label totalVenituriLabel;
        private Label venituriLunareLabel;
        private Label venituriZilniceLabel;
        private Label totalCheltuieliLabel;
        private Label cheltuieliLunareLabel;
        private Label cheltuieliZilniceLabel;
        private Label bilantTotalLabel;

        public DashboardPage()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
          
            this.BackColor = Color.White;

          
            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
                Padding = new Padding(20),
                BackColor = Color.White
            };

           
            for (int i = 0; i < 3; i++)
            {
                mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            }
            
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // First row - Venituri
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // Second row - Cheltuieli
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // Third row - Bilanț Total

            var totalVenituriPanel = CreateInfoPanel("Total Venituri", out totalVenituriLabel);
            var venituriLunarePanel = CreateInfoPanel("Venituri Lunare", out venituriLunareLabel);
            var venituriZilnicePanel = CreateInfoPanel("Venituri Zilnice", out venituriZilniceLabel);
            var totalCheltuieliPanel = CreateInfoPanel("Total Cheltuieli", out totalCheltuieliLabel);
            var cheltuieliLunarePanel = CreateInfoPanel("Cheltuieli Lunare", out cheltuieliLunareLabel);
            var cheltuieliZilnicePanel = CreateInfoPanel("Cheltuieli Zilnice", out cheltuieliZilniceLabel);
            var bilantTotalPanel = CreateInfoPanel("Bilanț Total", out bilantTotalLabel, true);

            // Add panels to the layout
            mainLayout.Controls.Add(totalVenituriPanel, 0, 0);
            mainLayout.Controls.Add(venituriLunarePanel, 1, 0);
            mainLayout.Controls.Add(venituriZilnicePanel, 2, 0);
            mainLayout.Controls.Add(totalCheltuieliPanel, 0, 1);
            mainLayout.Controls.Add(cheltuieliLunarePanel, 1, 1);
            mainLayout.Controls.Add(cheltuieliZilnicePanel, 2, 1);
            
            // Add Bilanț Total panel to the last row, spanning all columns
            mainLayout.Controls.Add(bilantTotalPanel, 0, 2);
            mainLayout.SetColumnSpan(bilantTotalPanel, 3);

            // Add the main layout to the control
            Controls.Add(mainLayout);
        }

        private Panel CreateInfoPanel(string title, out Label valueLabel, bool isLarge = false)
        {
            
            Panel panel = new Panel
            {
                BackColor = Color.FromArgb(101, 96, 184),
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                Margin = new Padding(8)
            };

          
            Label titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.TopCenter,
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Height = 25
            };

            
            valueLabel = new Label
            {
                Text = "0",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Bahnschrift SemiBold Condensed", isLarge ? 20 : 16, FontStyle.Bold),
                ForeColor = Color.White
            };
            
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(titleLabel);

            return panel;
        }

        public void UpdateData(double totalVenituri, double totalCheltuieli, double venituriLunare, double venituriZilnice, double cheltuieliLunare, double cheltuieliZilnice)
        {
            try
            {
               
                totalVenituriLabel.Text = $"{totalVenituri:C}";
                venituriLunareLabel.Text = $"{venituriLunare:C}";
                venituriZilniceLabel.Text = $"{venituriZilnice:C}";
                totalCheltuieliLabel.Text = $"{totalCheltuieli:C}";
                cheltuieliLunareLabel.Text = $"{cheltuieliLunare:C}";
                cheltuieliZilniceLabel.Text = $"{cheltuieliZilnice:C}";
                bilantTotalLabel.Text = $"{(totalVenituri - totalCheltuieli):C}";
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during label updates
                MessageBox.Show($"Eroare la actualizarea datelor în Dashboard: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
