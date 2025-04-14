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
        private Button searchButton;
        private Button addButton;
        private Panel listViewPanel;
        private ListView venituriListView;
        private Dictionary<int, Button> deleteButtons = new Dictionary<int, Button>();

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
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
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

            searchButton = new Button
            {
                Text = "Caută",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 35,
                Location = new Point(210, 5)
            };
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.Click += SearchButton_Click;

            addButton = new Button
            {
                Text = "Adaugă Venit",
                Font = new Font("Bahnschrift SemiBold Condensed", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 140,
                Height = 35,
                Location = new Point(mainLayout.Width - 170, 5),
                Anchor = AnchorStyles.Right
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddButton_Click;

            searchPanel.Controls.Add(searchTextBox);
            searchPanel.Controls.Add(searchButton);
            searchPanel.Controls.Add(addButton);
            searchPanel.Resize += (s, e) => 
            {
                addButton.Location = new Point(searchPanel.Width - 170, 5);
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

            venituriListView.Resize += VenituriListView_Resize;
            venituriListView.ItemSelectionChanged += VenituriListView_ItemSelectionChanged;
       

            listViewPanel.Controls.Add(venituriListView);

            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(searchPanel, 0, 1);
            mainLayout.Controls.Add(listViewPanel, 0, 2);

            Controls.Add(mainLayout);
        }

        private void IncarcaVenituri()
        {
            User currentUser = adminUser.GetUserCurent();
            if (currentUser != null)
            {
                venituri = adminTranzactii.GetTranzactiiUtilizatorDupaTip(currentUser.Id, TipTranzactie.Venit)
                    .OrderByDescending(t => t.DataTranzactie)
                    .ToList();

                ActualizeazaListaVenituri(venituri);
            }
        }

        private void ActualizeazaListaVenituri(List<Tranzactie> listaVenituri)
        {
            venituriListView.Items.Clear();
            ClearDeleteButtons();

            foreach (Tranzactie venit in listaVenituri)
            {
                ListViewItem item = new ListViewItem(venit.Id.ToString());
                item.SubItems.Add(venit.DataTranzactie.ToShortDateString());
                item.SubItems.Add(venit.Suma.ToString("N2"));
                item.SubItems.Add(venit.Valuta.ToString());
                item.SubItems.Add("Venit");
                item.SubItems.Add("");
                item.Tag = venit;

                venituriListView.Items.Add(item);
            }

            int currentLastColumnWidth = venituriListView.Columns[5].Width;
            
            for (int i = 0; i < venituriListView.Columns.Count - 1; i++)
            {
                venituriListView.Columns[i].Width = -2;
            }
            
            venituriListView.Columns[5].Width = 80;
            
            CreateDeleteButtons();
        }

        private void CreateDeleteButtons()
        {
            int buttonWidth = 60;
            int buttonHeight = 23;

            for (int i = 0; i < venituriListView.Items.Count; i++)
            {
                ListViewItem item = venituriListView.Items[i];
                
                Rectangle actionColumnBounds = GetSubItemBounds(item, 5);
                
                Button deleteButton = new Button
                {
                    Text = "Șterge",
                    Tag = item.Tag,
                    Size = new Size(buttonWidth, buttonHeight),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    Font = new Font("Bahnschrift SemiBold", 9, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.Click += DeleteButton_Click;
                
                int x = actionColumnBounds.X + (actionColumnBounds.Width - buttonWidth) / 2;
                int y = actionColumnBounds.Y + (actionColumnBounds.Height - buttonHeight) / 2;
                deleteButton.Location = new Point(x, y);
                
                listViewPanel.Controls.Add(deleteButton);
                deleteButtons[i] = deleteButton;
                
                deleteButton.BringToFront();
            }
        }

        private void ClearDeleteButtons()
        {
            foreach (Button button in deleteButtons.Values)
            {
                listViewPanel.Controls.Remove(button);
                button.Dispose();
            }

            deleteButtons.Clear();
        }

        private Rectangle GetSubItemBounds(ListViewItem item, int subItemIndex)
        {
            if (venituriListView.View != View.Details)
                return Rectangle.Empty;

            int columnWidth = 0;
            for (int i = 0; i < subItemIndex; i++)
            {
                columnWidth += venituriListView.Columns[i].Width;
            }

            Rectangle subItemRect = new Rectangle(
                columnWidth,
                item.Position.Y,
                venituriListView.Columns[subItemIndex].Width,
                item.Bounds.Height
            );

            return subItemRect;
        }

        private void UpdateDeleteButtonPositions()
        {
            int buttonWidth = 60;
            int buttonHeight = 23;

            for (int i = 0; i < venituriListView.Items.Count; i++)
            {
                if (deleteButtons.TryGetValue(i, out Button deleteButton))
                {
                    ListViewItem item = venituriListView.Items[i];
                    Rectangle actionColumnBounds = GetSubItemBounds(item, 5);
                    
                    if (item.Position.Y >= 0 && item.Position.Y <= venituriListView.ClientSize.Height)
                    {
                        int x = actionColumnBounds.X + (actionColumnBounds.Width - buttonWidth) / 2;
                        int y = actionColumnBounds.Y + (actionColumnBounds.Height - buttonHeight) / 2;
                        deleteButton.Location = new Point(x, y);
                        deleteButton.Visible = true;
                    }
                    else
                    {
                        deleteButton.Visible = false;
                    }
                }
            }
        }

        private void VenituriListView_Resize(object sender, EventArgs e)
        {
            UpdateDeleteButtonPositions();
        }

        private void VenituriListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            UpdateDeleteButtonPositions();
        }

        private void VenituriListView_Scroll(object sender, EventArgs e)
        {
            UpdateDeleteButtonPositions();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (sender is Button deleteButton && deleteButton.Tag is Tranzactie tranzactie)
            {
                int tranzactieId = tranzactie.Id;
                
                var confirmResult = MessageBox.Show(
                    "Sigur doriți să ștergeți această tranzacție?", 
                    "Confirmare Ștergere", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);
                
                if (confirmResult == DialogResult.Yes)
                {
                    if (adminTranzactii.StergeTranzactie(tranzactieId))
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(searchTerm))
            {
                ActualizeazaListaVenituri(venituri);
                return;
            }

            var rezultateCautare = venituri.Where(v =>
                v.Id.ToString().Contains(searchTerm) ||
                v.DataTranzactie.ToString("dd.MM.yyyy").Contains(searchTerm) ||
                v.Suma.ToString().Contains(searchTerm) ||
                v.Valuta.ToString().ToLower().Contains(searchTerm)
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
        private Label sumaLabel;
        private TextBox sumaTextBox;
        private Label valutaLabel;
        private ComboBox valutaComboBox;
        private Label dataLabel;
        private DateTimePicker dataPicker;
        private Button saveButton;
        private Button cancelButton;

        public AdaugaVenitForm(AdminUser adminUser, AdminTranzactii adminTranzactii)
        {
            this.adminUser = adminUser;
            this.adminTranzactii = adminTranzactii;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Adaugă Venit Nou";
            this.Size = new Size(400, 250);
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
            sumaTextBox.KeyPress += (s, e) => 
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && (s as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
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
                {
                    valutaComboBox.Items.Add(valuta);
                }
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
                Text = "Salvează",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 96, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(80, 160),
                Size = new Size(100, 30)
            };
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Anulează",
                Font = new Font("Bahnschrift SemiBold Condensed", 12, FontStyle.Bold),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 160),
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sumaTextBox.Text))
                {
                    MessageBox.Show("Vă rugăm să introduceți o sumă.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
