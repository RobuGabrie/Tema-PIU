using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Modele.ClaseModele;

namespace ProiectBanca
{
    public class VenituriPage : UserControl
    {
        private AdminUser adminUser;
        private AdminTranzactii adminTranzactii;
        private List<Tranzactie> venituri;

        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Panel searchPanel;
        private TextBox searchTextBox;
        private ComboBox searchFieldComboBox;
        private Button searchButton;
        private Button addButton;
        private Panel listViewPanel;
        private ListView venituriListView;

        private RadioButton idRadioButton;
        private RadioButton dataRadioButton;
        private RadioButton sumaRadioButton;
        private RadioButton valutaRadioButton;
        private RadioButton descriereRadioButton;


        public VenituriPage(AdminUser adminUser)
        {
            this.adminUser = adminUser;
            adminTranzactii = new AdminTranzactii();
            InitializeComponents();
            IncarcaVenituri();
        }

        private void InitializeComponents()
        {
            this.BackColor = Color.White;

            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            titleLabel = new Label
            {
                Text = "Venituri",
                Font = new Font("Bahnschrift SemiBold Condensed", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 96, 184),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            searchPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            searchTextBox = new TextBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Regular),
                Width = 200,
                Location = new Point(0, 10),
                PlaceholderText = "Caută venituri..."
            };

            searchFieldComboBox = new ComboBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Regular),
                Width = 120,
                Location = new Point(210, 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            searchFieldComboBox.Items.AddRange(new string[] { "ID", "Data", "Suma", "Valuta", "Descriere" });
            searchFieldComboBox.SelectedIndex = 0;

            searchButton = new Button
            {
                Text = "Cauta",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 30,
                Location = new Point(340, 10)
            };
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.Click += SearchButton_Click;

            idRadioButton = new RadioButton
            {
                Text = "ID",
                Font = new Font("Bahnschrift SemiBold Condensed", 10, FontStyle.Regular),
                Location = new Point(0, 50),
                AutoSize = true,
                Checked = true
            };
            dataRadioButton = new RadioButton
            {
                Text = "Data",
                Font = new Font("Bahnschrift SemiBold Condensed", 10, FontStyle.Regular),
                Location = new Point(50, 50),
                AutoSize = true
            };
            sumaRadioButton = new RadioButton
            {
                Text = "Suma",
                Font = new Font("Bahnschrift SemiBold Condensed", 10, FontStyle.Regular),
                Location = new Point(110, 50),
                AutoSize = true
            };
            valutaRadioButton = new RadioButton
            {
                Text = "Valuta",
                Font = new Font("Bahnschrift SemiBold Condensed", 10, FontStyle.Regular),
                Location = new Point(180, 50),
                AutoSize = true
            };
            descriereRadioButton = new RadioButton
            {
                Text = "Descriere",
                Font = new Font("Bahnschrift SemiBold Condensed", 10, FontStyle.Regular),
                Location = new Point(260, 50),
                AutoSize = true
            };

            idRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            dataRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            sumaRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            valutaRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            descriereRadioButton.CheckedChanged += RadioButton_CheckedChanged;



            addButton = new Button
            {
                Text = "Adaugă Venit",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 150,
                Height = 35,
                Location = new Point(500, 10),
                Anchor = AnchorStyles.Right
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddButton_Click;

            searchPanel.Controls.Add(searchTextBox);
            searchPanel.Controls.Add(searchFieldComboBox);
            searchPanel.Controls.Add(searchButton);
            searchPanel.Controls.Add(addButton);
            searchPanel.Controls.Add(idRadioButton);
            searchPanel.Controls.Add(dataRadioButton);
            searchPanel.Controls.Add(sumaRadioButton);
            searchPanel.Controls.Add(valutaRadioButton);
            searchPanel.Controls.Add(descriereRadioButton);
          

            searchPanel.Resize += (s, e) =>
            {
                addButton.Location = new Point(searchPanel.Width - addButton.Width - 10, 10);
            };

            listViewPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            venituriListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Regular),
                MultiSelect = false
            };

            venituriListView.Columns.Add("ID", 50);
            venituriListView.Columns.Add("Data", 100);
            venituriListView.Columns.Add("Suma", 100);
            venituriListView.Columns.Add("Valuta", 80);
            venituriListView.Columns.Add("Descriere", 200);
            venituriListView.Columns.Add("Acțiuni", 80);
            venituriListView.Columns.Add("Editare", 80);

            venituriListView.MouseClick += VenituriListView_MouseClick;

            listViewPanel.Controls.Add(venituriListView);

            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(searchPanel, 0, 1);
            mainLayout.Controls.Add(listViewPanel, 0, 2);

            Controls.Add(mainLayout);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (idRadioButton.Checked) searchFieldComboBox.SelectedItem = "ID";
            else if (dataRadioButton.Checked) searchFieldComboBox.SelectedItem = "Data";
            else if (sumaRadioButton.Checked) searchFieldComboBox.SelectedItem = "Suma";
            else if (valutaRadioButton.Checked) searchFieldComboBox.SelectedItem = "Valuta";
            else if (descriereRadioButton.Checked) searchFieldComboBox.SelectedItem = "Descriere";
        }

         
        private void IncarcaVenituri()
        {
            User currentUser = adminUser.GetUserCurent();
            if (currentUser != null)
            {
                venituri = adminTranzactii.GetTranzactiiUtilizatorDupaTip(currentUser.Id, TipTranzactie.Venit)
                    .OrderByDescending(t => t.DataTranzactie)
                    .ToList();
                ApplyFilters();
            }
        }

        private void ApplyFilters()
        {
            List<Tranzactie> filteredVenituri = venituri;
           
            ActualizeazaListaVenituri(filteredVenituri);
        }

        private void ActualizeazaListaVenituri(List<Tranzactie> listaVenituri)
        {
            venituriListView.Items.Clear();

            foreach (var venit in listaVenituri)
            {
                ListViewItem item = new ListViewItem(venit.Id.ToString());
                item.SubItems.Add(venit.DataTranzactie.ToShortDateString());
                item.SubItems.Add(venit.Suma.ToString("N2"));
                item.SubItems.Add(venit.Valuta.ToString());
                item.SubItems.Add("Venit");
                item.SubItems.Add("Șterge");
                item.SubItems.Add("Editare");
                item.Tag = venit;
                venituriListView.Items.Add(item);
            }

            for (int i = 0; i < venituriListView.Columns.Count - 1; i++)
                venituriListView.Columns[i].Width = -2;
            
        }

        private void VenituriListView_MouseClick(object sender, MouseEventArgs e)
        {
            var info = venituriListView.HitTest(e.Location);
            if (info.Item != null && info.SubItem != null)
            {
                int colIndex = info.Item.SubItems.IndexOf(info.SubItem);
                if (colIndex == 5)
                {
                    Tranzactie tranzactie = info.Item.Tag as Tranzactie;
                    if (tranzactie != null)
                    {
                        var confirmResult = MessageBox.Show(
                            "Sigur doriți să ștergeți această tranzacție?",
                            "Confirmare Ștergere",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirmResult == DialogResult.Yes)
                        {
                            if (adminTranzactii.StergeTranzactie(tranzactie.Id))
                            {
                                MessageBox.Show(
                                    "Tranzacția a fost ștearsă cu succes.",
                                    "Succes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                IncarcaVenituri();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Eroare la ștergerea tranzacției.",
                                    "Eroare",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                if (colIndex == 6)
                {
                    Tranzactie tranzactie = info.Item.Tag as Tranzactie;
                    if (tranzactie != null)
                    {
                        AdaugaVenitForm editVenitForm = new AdaugaVenitForm(adminUser, adminTranzactii);
                        editVenitForm.Text = "Editare Venit";
                        editVenitForm.sumaTextBox.Text = tranzactie.Suma.ToString("N2");
                        editVenitForm.valutaComboBox.SelectedItem = tranzactie.Valuta;
                        editVenitForm.dataPicker.Value = tranzactie.DataTranzactie;
                        editVenitForm.saveButton.Text = "Salvează";

                        // Afișează formularul și verifică dacă a fost salvat
                        if (editVenitForm.ShowDialog() == DialogResult.OK)
                        {
                            // Validare și salvare după închiderea formularului
                            if (string.IsNullOrWhiteSpace(editVenitForm.sumaTextBox.Text))
                            {
                                MessageBox.Show("Vă rugăm să introduceți o sumă.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (!double.TryParse(editVenitForm.sumaTextBox.Text, out double suma))
                            {
                                MessageBox.Show("Sumă invalidă.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            Valuta valuta = (Valuta)editVenitForm.valutaComboBox.SelectedItem;
                            DateTime data = editVenitForm.dataPicker.Value;

                            Tranzactie tranzactieEditata = new Tranzactie(
                                valuta,
                                suma,
                                data,
                                tranzactie.UserId,
                                TipTranzactie.Venit
                            );
                            tranzactieEditata.Id = tranzactie.Id;

                            adminTranzactii.ActualizeazaTranzactie(tranzactie.Id, tranzactieEditata);
                            IncarcaVenituri();
                        }
                    }
                }

            }
        }
        

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim().ToLower();
            string selectedField = searchFieldComboBox.SelectedItem.ToString();

            if (string.IsNullOrEmpty(searchTerm))
            {
                ApplyFilters();
                return;
            }

            var rezultateCautare = venituri.Where(v =>
                (selectedField == "ID" && v.Id.ToString().Contains(searchTerm)) ||
                (selectedField == "Data" && v.DataTranzactie.ToString("dd.MM.yyyy").Contains(searchTerm)) ||
                (selectedField == "Suma" && v.Suma.ToString().Contains(searchTerm)) ||
                (selectedField == "Valuta" && v.Valuta.ToString().ToLower().Contains(searchTerm)) ||
                (selectedField == "Descriere" && "Venit".ToLower().Contains(searchTerm))
            ).ToList();

          

            ActualizeazaListaVenituri(rezultateCautare);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var adaugaVenitForm = new AdaugaVenitForm(adminUser, adminTranzactii))
            {
                if (adaugaVenitForm.ShowDialog() == DialogResult.OK)
                {
                    IncarcaVenituri();
                }
            }
        }
    }

    public class AdaugaVenitForm : Form
    {
        private AdminUser adminUser;
        private AdminTranzactii adminTranzactii;
        public Label sumaLabel;
        public TextBox sumaTextBox;
        public Label valutaLabel;
        public ComboBox valutaComboBox;
        public Label dataLabel;
        public DateTimePicker dataPicker;
        public Button saveButton;
        public Button cancelButton;
      

        public AdaugaVenitForm(AdminUser adminUser, AdminTranzactii adminTranzactii)
        {
            this.adminUser = adminUser;
            this.adminTranzactii = adminTranzactii;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Adauga Venit Nou";
            this.Size = new Size(400, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            sumaLabel = new Label
            {
                Text = "Suma:",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(100, 25)
            };

            sumaTextBox = new TextBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Regular),
                Location = new Point(160, 20),
                Size = new Size(200, 25)
            };
           

            valutaLabel = new Label
            {
                Text = "Valuta:",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                Location = new Point(20, 60),
                Size = new Size(100, 25)
            };

            valutaComboBox = new ComboBox
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Regular),
                Location = new Point(160, 60),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            foreach (Valuta valuta in Enum.GetValues(typeof(Valuta)))
            {
                if (valuta != Valuta.NEDEFINITA)
                    valutaComboBox.Items.Add(valuta);
            }
            valutaComboBox.SelectedItem = Valuta.RON;

            dataLabel = new Label
            {
                Text = "Data:",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                Location = new Point(20, 100),
                Size = new Size(100, 25)
            };

            dataPicker = new DateTimePicker
            {
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Regular),
                Location = new Point(160, 100),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };


            saveButton = new Button
            {
                Text = "Salveaza",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(80, 200),
                Size = new Size(100, 30)
            };
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Anuleaza",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 200),
                Size = new Size(100, 30)
            };
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(sumaLabel);
            this.Controls.Add(sumaTextBox);
            this.Controls.Add(valutaLabel);
            this.Controls.Add(valutaComboBox);
            this.Controls.Add(dataLabel);
            this.Controls.Add(dataPicker);
         
            this.Controls.Add(saveButton);
            this.Controls.Add(cancelButton);
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sumaTextBox.Text))
                {
                    MessageBox.Show("Va rugam sa introduceti o suma.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double suma = double.Parse(sumaTextBox.Text);
                Valuta valuta = (Valuta)valutaComboBox.SelectedItem;
                DateTime data = dataPicker.Value;
                User currentUser = adminUser.GetUserCurent();

                if (currentUser != null)
                {
                    Tranzactie venit = new Tranzactie(valuta, suma, data, currentUser.Id, TipTranzactie.Venit);
                    adminTranzactii.AdaugaTranzactie(venit);

                    string message = "Venitul a fost adaugat cu succes.";

                    MessageBox.Show(message, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Utilizator necunoscut. Vă rugăm să vă autentificați din nou.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea venitului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
