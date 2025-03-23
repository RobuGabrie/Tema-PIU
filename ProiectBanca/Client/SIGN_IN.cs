using System;
using System.Windows.Forms;
using Modele.ClaseModele;

namespace ProiectBanca
{
    public partial class SIGN_IN : Form
    {
        private AdminUser adminUser;
        private bool isRegisterMode = false;

        public SIGN_IN()
        {
            InitializeComponent();
            adminUser = new AdminUser();
            SetLoginMode();
            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initializare formular
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Logica pentru desenare panel
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Logica click pe label1
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Logica click pe label5
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Logica click pe label6
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Logica pentru modificare text in textBox1
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Va rugam completati toate campurile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isRegisterMode)
            {
                
                if (adminUser.Inregistrare(username, username + "@example.com", password))
                {
                    MessageBox.Show("Inregistrare reusita! Acum va puteti autentifica.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetLoginMode();
                }
                else
                {
                    MessageBox.Show("Inregistrare esuata. Utilizatorul exista deja.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (adminUser.Autentificare(username + "@example.com", password))
                {
                    MessageBox.Show("Autentificare reusita!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
                    MAIN mainForm = new MAIN(adminUser);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Autentificare esuata. Verificati username-ul si parola.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
        private void SetLoginMode()
        {
            isRegisterMode = false;
            label4.Text = "SIGN IN";
            button1.Text = "Confirma";

            linkLabel1.Text = "Nu aveti cont? Inregistrati-va aici.";
            linkLabel1.Refresh();
        }

        private void SetRegisterMode()
        {
            isRegisterMode = true;
            label4.Text = "REGISTER";
            button1.Text = "Inregistrare";
           
            linkLabel1.Text = "Aveti deja cont? Autentificati-va aici.";
            linkLabel1.Refresh();
        }

      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
             if (isRegisterMode)
             {
                 SetLoginMode();
             }
             else
             {
                SetRegisterMode();
             }
         }
    }
}
