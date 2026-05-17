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
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblKoneksi = new System.Windows.Forms.Label();
            this.gbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 2;
            // 
            // btnPemilik
            // 
            this.btnPemilik.Location = new System.Drawing.Point(132, 50);
            this.btnPemilik.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPemilik.Name = "btnPemilik";
            this.btnPemilik.Size = new System.Drawing.Size(176, 51);
            this.btnPemilik.TabIndex = 12;
            this.btnPemilik.Text = "Kelola Data Pemilik";
            this.btnPemilik.UseVisualStyleBackColor = true;
            this.btnPemilik.Click += new System.EventHandler(this.btnPemilik_Click);
            // 
            // btnUMKM
            // 
            this.btnUMKM.Location = new System.Drawing.Point(132, 142);
            this.btnUMKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUMKM.Name = "btnUMKM";
            this.btnUMKM.Size = new System.Drawing.Size(176, 50);
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
            this.btnLogout.Location = new System.Drawing.Point(711, 569);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(176, 46);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnProduk
            // 
            this.btnProduk.Location = new System.Drawing.Point(132, 238);
            this.btnProduk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProduk.Name = "btnProduk";
            this.btnProduk.Size = new System.Drawing.Size(176, 44);
            this.btnProduk.TabIndex = 16;
            this.btnProduk.Text = "Kelola Data Produk";
            this.btnProduk.UseVisualStyleBackColor = true;
            this.btnProduk.Click += new System.EventHandler(this.btnKeProduk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(541, 45);
            this.label1.TabIndex = 17;
            this.label1.Text = "SISTEM INFORMASI UMKM DESA";
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.button2);
            this.gbMenu.Controls.Add(this.btnUMKM);
            this.gbMenu.Controls.Add(this.btnPemilik);
            this.gbMenu.Controls.Add(this.btnProduk);
            this.gbMenu.Location = new System.Drawing.Point(281, 154);
            this.gbMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbMenu.Size = new System.Drawing.Size(428, 408);
            this.gbMenu.TabIndex = 18;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menu Navigasi Utama";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 329);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 40);
            this.button2.TabIndex = 18;
            this.button2.Text = "Laporan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblKoneksi
            // 
            this.lblKoneksi.AutoSize = true;
            this.lblKoneksi.Location = new System.Drawing.Point(238, 584);
            this.lblKoneksi.Name = "lblKoneksi";
            this.lblKoneksi.Size = new System.Drawing.Size(65, 20);
            this.lblKoneksi.TabIndex = 19;
            this.lblKoneksi.Text = "Koneksi";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 702);
            this.Controls.Add(this.lblKoneksi);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    }
}