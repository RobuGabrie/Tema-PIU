namespace ProiectBanca
{
    public partial class SIGN_IN : Form
    {
        public SIGN_IN()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
    

            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                    this.Hide();
                    new MAIN().Show();

            }
            else
            {
                    MessageBox.Show("Username sau parola gresita!");
            }
            
        }
    }
}
