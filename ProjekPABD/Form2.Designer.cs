namespace ProjekPABD
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnPemilik = new System.Windows.Forms.Button();
            this.btnUMKM = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnProduk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblKoneksi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 2;
            // 
            // btnPemilik
            // 
            this.btnPemilik.Location = new System.Drawing.Point(117, 40);
            this.btnPemilik.Name = "btnPemilik";
            this.btnPemilik.Size = new System.Drawing.Size(156, 41);
            this.btnPemilik.TabIndex = 12;
            this.btnPemilik.Text = "Kelola Data Pemilik";
            this.btnPemilik.UseVisualStyleBackColor = true;
            this.btnPemilik.Click += new System.EventHandler(this.btnPemilik_Click);
            // 
            // btnUMKM
            // 
            this.btnUMKM.Location = new System.Drawing.Point(117, 114);
            this.btnUMKM.Name = "btnUMKM";
            this.btnUMKM.Size = new System.Drawing.Size(156, 40);
            this.btnUMKM.TabIndex = 13;
            this.btnUMKM.Text = "Kelola Data UMKM";
            this.btnUMKM.UseVisualStyleBackColor = true;
            this.btnUMKM.Click += new System.EventHandler(this.btnKeUMKM_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(632, 455);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(156, 37);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnProduk
            // 
            this.btnProduk.Location = new System.Drawing.Point(117, 190);
            this.btnProduk.Name = "btnProduk";
            this.btnProduk.Size = new System.Drawing.Size(156, 35);
            this.btnProduk.TabIndex = 16;
            this.btnProduk.Text = "Kelola Data Produk";
            this.btnProduk.UseVisualStyleBackColor = true;
            this.btnProduk.Click += new System.EventHandler(this.btnKeProduk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "SISTEM INFORMASI UMKM DESA";
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.button2);
            this.gbMenu.Controls.Add(this.button1);
            this.gbMenu.Controls.Add(this.btnUMKM);
            this.gbMenu.Controls.Add(this.btnPemilik);
            this.gbMenu.Controls.Add(this.btnProduk);
            this.gbMenu.Location = new System.Drawing.Point(250, 123);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(380, 326);
            this.gbMenu.TabIndex = 18;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menu Navigasi Utama";
            // 
            // lblKoneksi
            // 
            this.lblKoneksi.AutoSize = true;
            this.lblKoneksi.Location = new System.Drawing.Point(212, 467);
            this.lblKoneksi.Name = "lblKoneksi";
            this.lblKoneksi.Size = new System.Drawing.Size(55, 16);
            this.lblKoneksi.TabIndex = 19;
            this.lblKoneksi.Text = "Koneksi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 32);
            this.button2.TabIndex = 18;
            this.button2.Text = "Laporan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 562);
            this.Controls.Add(this.lblKoneksi);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gbMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPemilik;
        private System.Windows.Forms.Button btnUMKM;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnProduk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblKoneksi;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}