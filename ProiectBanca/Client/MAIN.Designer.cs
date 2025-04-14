using System;
using Modele.ClaseModele;
using ProiectBanca;

namespace ProiectBanca
{
    partial class MAIN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAIN));
            label1 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox6 = new PictureBox();
            button3 = new Button();
            pictureBox5 = new PictureBox();
            button2 = new Button();
            pictureBox4 = new PictureBox();
            button1 = new Button();
            label5 = new Label();
            imageList1 = new ImageList(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(101, 96, 184);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 653);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.White;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(17, 301);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(35, 38);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 13;
            pictureBox6.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(101, 96, 254);
            button3.Location = new Point(13, 296);
            button3.Name = "button3";
            button3.Size = new Size(222, 48);
            button3.TabIndex = 12;
            button3.Text = "Schimb valutar";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.White;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(17, 234);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 36);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(101, 96, 254);
            button2.Location = new Point(13, 229);
            button2.Name = "button2";
            button2.Size = new Size(222, 46);
            button2.TabIndex = 10;
            button2.Text = "Cheltuieli";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(17, 168);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 36);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(101, 96, 254);
            button1.Location = new Point(13, 164);
            button1.Name = "button1";
            button1.Size = new Size(222, 46);
            button1.TabIndex = 8;
            button1.Text = "Venituri";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(76, 34);
            label5.Name = "label5";
            label5.Size = new Size(72, 34);
            label5.TabIndex = 7;
            label5.Text = "ADMIN";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // MAIN
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1142, 653);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MAIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Management";
            Load += MAIN_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();

            // Ensure button click events are correctly wired
            button1.Click += Button1_Click; // Venituri button
            button2.Click += Button2_Click; // Cheltuieli button
            button3.Click += Button3_Click; // Schimb Valutar button

            // Add a new button for Dashboard if not already present
            Button dashboardButton = new Button
            {
                Text = "Dashboard",
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 96, 254),
                Location = new Point(13, 100), // Adjust location as needed
                Size = new Size(222, 46),
                TextAlign = ContentAlignment.MiddleRight
            };
            dashboardButton.Click += DashboardButton_Click;
            panel1.Controls.Add(dashboardButton);

            // Initialize panel2
            panel2 = new Panel
            {
                BackColor = Color.White,
                Location = new Point(250, 0), // Adjust location as needed
                Name = "panel2",
                Size = new Size(892, 653), // Adjust size as needed
                TabIndex = 3
            };

            // Add panel2 to the form
            Controls.Add(panel2);
        }

        #endregion
        private Label label1;
        private SaveFileDialog saveFileDialog1;
        private Panel panel1;
        private ImageList imageList1;
        private Label label5;
        private PictureBox pictureBox6;
        private Button button3;
        private PictureBox pictureBox5;
        private Button button2;
        private PictureBox pictureBox4;
        private Button button1;
        private PictureBox pictureBox1;
        private Panel panel2; // Add this declaration for panel2
    }
}