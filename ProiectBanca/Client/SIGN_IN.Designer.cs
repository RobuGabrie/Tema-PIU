namespace ProiectBanca
{
    partial class SIGN_IN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SIGN_IN));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            linkLabel1 = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(101, 96, 184);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(618, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(395, 607);
            panel1.TabIndex = 0;
    
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift Condensed", 13.8F);
            label3.ForeColor = Color.CornflowerBlue;
            label3.Location = new Point(72, 309);
            label3.Name = "label3";
            label3.Size = new Size(230, 28);
            label3.TabIndex = 3;
            label3.Text = "organizeaza-ti banii eficient";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 306);
            label2.Name = "label2";
            label2.Size = new Size(0, 34);
            label2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 22.2F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(38, 264);
            label1.Name = "label1";
            label1.Size = new Size(302, 45);
            label1.TabIndex = 1;
            label1.Text = "Management tranzactii";
            label1.TextAlign = ContentAlignment.MiddleCenter;
        
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(82, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(165, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift Condensed", 25.8000011F, FontStyle.Bold);
            label4.Location = new Point(248, 63);
            label4.Name = "label4";
            label4.Size = new Size(126, 53);
            label4.TabIndex = 1;
            label4.Text = "SIGN IN";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift Condensed", 18F);
            label5.Location = new Point(119, 138);
            label5.Name = "label5";
            label5.Size = new Size(115, 36);
            label5.TabIndex = 2;
            label5.Text = "Username";
      
            textBox1.Font = new Font("Bahnschrift SemiLight Condensed", 12F);
            textBox1.Location = new Point(119, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(378, 32);
            textBox1.TabIndex = 3;
        
            label6.AutoSize = true;
            label6.Font = new Font("Bahnschrift Condensed", 18F);
            label6.Location = new Point(119, 257);
            label6.Name = "label6";
            label6.Size = new Size(78, 36);
            label6.TabIndex = 4;
            label6.Text = "Parola";
        
            textBox2.Font = new Font("Bahnschrift SemiLight Condensed", 12F);
            textBox2.Location = new Point(119, 307);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(378, 32);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(101, 96, 184);
            button1.Font = new Font("Bahnschrift Condensed", 18F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(248, 412);
            button1.Name = "button1";
            button1.Size = new Size(126, 55);
            button1.TabIndex = 6;
            button1.Text = "Confirma";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Bahnschrift Light Condensed", 10.2F);
            checkBox1.Location = new Point(119, 345);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(102, 25);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Arata parola";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.Font = new Font("Bahnschrift SemiLight SemiConde", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(119, 373);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(78, 21);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "linkLabel2";
            // 
            // SIGN_IN
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(618, 529);
            Controls.Add(linkLabel1);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(panel1);
            Font = new Font("Bahnschrift Condensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SIGN_IN";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Management tranzactii";
         
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBox2;
        private Button button1;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
    }

}
