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
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox6 = new PictureBox();
            button3 = new Button();
            pictureBox5 = new PictureBox();
            button2 = new Button();
            pictureBox4 = new PictureBox();
            button1 = new Button();
            label5 = new Label();
            imageList1 = new ImageList(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            panel4 = new Panel();
            Totalv = new Label();
            Totalc = new Label();
            venituri = new Label();
            cheltuieli = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
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
            panel1.Controls.Add(panel2);
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
            // panel2
            // 
            panel2.Location = new Point(241, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(901, 653);
            panel2.TabIndex = 4;
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Location = new Point(256, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(883, 647);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(101, 96, 184);
            panel3.Controls.Add(venituri);
            panel3.Controls.Add(Totalv);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(435, 317);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(101, 96, 184);
            panel4.Controls.Add(cheltuieli);
            panel4.Controls.Add(Totalc);
            panel4.Location = new Point(444, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(435, 317);
            panel4.TabIndex = 1;
            // 
            // Totalv
            // 
            Totalv.Font = new Font("Bahnschrift Condensed", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Totalv.ForeColor = Color.White;
            Totalv.Location = new Point(22, 44);
            Totalv.Name = "Totalv";
            Totalv.Size = new Size(221, 43);
            Totalv.TabIndex = 0;
            Totalv.Text = "Total Venituri";
 
            // 
            // Totalc
            // 
            Totalc.Font = new Font("Bahnschrift Condensed", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Totalc.ForeColor = Color.White;
            Totalc.Location = new Point(37, 44);
            Totalc.Name = "Totalc";
            Totalc.Size = new Size(221, 43);
            Totalc.TabIndex = 1;
            Totalc.Text = "Total Cheltuieli";
            // 
            // venituri
            // 
            venituri.Font = new Font("Bahnschrift Condensed", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            venituri.ForeColor = Color.White;
            venituri.Location = new Point(109, 140);
            venituri.Name = "venituri";
            venituri.Size = new Size(248, 71);
            venituri.TabIndex = 1;
            venituri.Text = "0";
        
            // 
            // cheltuieli
            // 
            cheltuieli.Font = new Font("Bahnschrift Condensed", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cheltuieli.ForeColor = Color.White;
            cheltuieli.Location = new Point(127, 140);
            cheltuieli.Name = "cheltuieli";
            cheltuieli.Size = new Size(246, 81);
            cheltuieli.TabIndex = 2;
            cheltuieli.Text = "0";
            // 
            // MAIN
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1142, 653);
            Controls.Add(tableLayoutPanel1);
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
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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

        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel3;
        private Label Totalv;
        private Label cheltuieli;
        private Label Totalc;
        private Label venituri;
    }
}