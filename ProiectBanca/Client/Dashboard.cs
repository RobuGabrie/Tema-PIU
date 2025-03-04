using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdministrareDate.Administrari;
using Modele.ClaseModele;

namespace ProiectBanca.Client
{
    public partial class Dashboard : UserControl
    {
        private AdministrareVenituri adminVenituri = new AdministrareVenituri();

        public Dashboard()
        {
            InitializeComponent();
            UpdateVenitAzi();
        }

        private void UpdateVenitAzi()
        {
            List<Venit> venituri = adminVenituri.GetVenituriZi();
            double totalVenituri = 0;
            foreach (Venit venit in venituri)
            {
                totalVenituri += venit.Suma;
            }
            VenitAzi.Text = totalVenituri.ToString() + "RON";

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
