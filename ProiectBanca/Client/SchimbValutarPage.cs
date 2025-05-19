using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Modele.ClaseModele;

namespace ProiectBanca
{
    public class SchimbValutarPage : UserControl
    {
        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label amountLabel;
        private TextBox amountTextBox;
        private Label sourceCurrencyLabel;
        private ComboBox sourceCurrencyComboBox;
        private Label destinationCurrencyLabel;
        private ComboBox destinationCurrencyComboBox;
        private Button convertButton;
        private Label resultLabel;
        private AdminTranzactii adminTranzactii;

        public SchimbValutarPage()
        {
            adminTranzactii = new AdminTranzactii();
            InitializeComponents();
            LoadCurrencies();
        }

        private void InitializeComponents()
        {
      
            this.BackColor = Color.White;

            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 6,
                Padding = new Padding(30),
                BackColor = Color.White
            };

           
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); 
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); 
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); 
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80)); 

         
            titleLabel = new Label
            {
                Text = "Schimb Valutar",
                Font = new Font("Bahnschrift SemiBold Condensed", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 96, 184),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

          
            amountLabel = new Label
            {
                Text = "Sumă:",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            amountTextBox = new TextBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Regular),
                Dock = DockStyle.Fill,
                Margin = new Padding(3)
            };
            amountTextBox.KeyPress += AmountTextBox_KeyPress;

            // Create source currency label and combobox
            sourceCurrencyLabel = new Label
            {
                Text = "Din valuta:",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            sourceCurrencyComboBox = new ComboBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Margin = new Padding(3)
            };

            // Create destination currency label and combobox
            destinationCurrencyLabel = new Label
            {
                Text = "În valuta:",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            destinationCurrencyComboBox = new ComboBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Margin = new Padding(3)
            };

            // Create convert button
            convertButton = new Button
            {
                Text = "Convertește",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Fill,
                Margin = new Padding(50, 5, 50, 5)
            };
            convertButton.FlatAppearance.BorderSize = 0;
            convertButton.Click += ConvertButton_Click;

            // Create result label
            resultLabel = new Label
            {
                Text = "Rezultat: ",
                Font = new Font("Bahnschrift SemiBold Condensed", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 96, 184),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Add controls to the layout
            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.SetColumnSpan(titleLabel, 2);

            mainLayout.Controls.Add(amountLabel, 0, 1);
            mainLayout.Controls.Add(amountTextBox, 1, 1);

            mainLayout.Controls.Add(sourceCurrencyLabel, 0, 2);
            mainLayout.Controls.Add(sourceCurrencyComboBox, 1, 2);

            mainLayout.Controls.Add(destinationCurrencyLabel, 0, 3);
            mainLayout.Controls.Add(destinationCurrencyComboBox, 1, 3);

            mainLayout.Controls.Add(convertButton, 0, 4);
            mainLayout.SetColumnSpan(convertButton, 2);

            mainLayout.Controls.Add(resultLabel, 0, 5);
            mainLayout.SetColumnSpan(resultLabel, 2);

            // Add the main layout to the control
            Controls.Add(mainLayout);
        }

        private void LoadCurrencies()
        {
            // Load currencies from the RateValutare class
            foreach (KeyValuePair<string, double> rate in RateValutare.Rate)
            {
                sourceCurrencyComboBox.Items.Add(rate.Key);
                destinationCurrencyComboBox.Items.Add(rate.Key);
            }

            // Set default selections if items exist
            if (sourceCurrencyComboBox.Items.Count > 0)
            {
                sourceCurrencyComboBox.SelectedIndex = 0;
            }

            if (destinationCurrencyComboBox.Items.Count > 1)
            {
                destinationCurrencyComboBox.SelectedIndex = 1;
            }
            else if (destinationCurrencyComboBox.Items.Count > 0)
            {
                destinationCurrencyComboBox.SelectedIndex = 0;
            }
        }

        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrEmpty(amountTextBox.Text))
                {
                    MessageBox.Show("Vă rugăm să introduceți o sumă.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (sourceCurrencyComboBox.SelectedItem == null || destinationCurrencyComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Vă rugăm să selectați valutele pentru conversie.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get values from controls
                double amount = double.Parse(amountTextBox.Text);
                string sourceCurrency = sourceCurrencyComboBox.SelectedItem.ToString();
                string destinationCurrency = destinationCurrencyComboBox.SelectedItem.ToString();

                // Perform the conversion
                double convertedAmount = adminTranzactii.SchimbValutar(amount, sourceCurrency, destinationCurrency);

                // Display the result
                resultLabel.Text = $"Rezultat: {amount} {sourceCurrency} = {convertedAmount:N2} {destinationCurrency}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la conversia valutară: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
