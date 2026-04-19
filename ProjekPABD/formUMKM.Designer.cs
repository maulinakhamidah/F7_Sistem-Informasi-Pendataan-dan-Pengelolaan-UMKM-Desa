namespace ProjekPABD
{
    partial class formUMKM
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
            this.lblNama = new System.Windows.Forms.Label();
            this.lblJenis = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblDesk = new System.Windows.Forms.Label();
            this.lblPemilik = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtDesk = new System.Windows.Forms.TextBox();
            this.cmbJenis = new System.Windows.Forms.ComboBox();
            this.cmbPemilik = new System.Windows.Forms.ComboBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvUMKM = new System.Windows.Forms.DataGridView();
            this.lblCari = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUMKM)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(233, 46);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(87, 16);
            this.lblNama.TabIndex = 0;
            this.lblNama.Text = "Nama Usaha";
            // 
            // lblJenis
            // 
            this.lblJenis.AutoSize = true;
            this.lblJenis.Location = new System.Drawing.Point(233, 81);
            this.lblJenis.Name = "lblJenis";
            this.lblJenis.Size = new System.Drawing.Size(82, 16);
            this.lblJenis.TabIndex = 1;
            this.lblJenis.Text = "Jenis Usaha";
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(233, 118);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(49, 16);
            this.lblAlamat.TabIndex = 2;
            this.lblAlamat.Text = "Alamat";
            // 
            // lblDesk
            // 
            this.lblDesk.AutoSize = true;
            this.lblDesk.Location = new System.Drawing.Point(233, 153);
            this.lblDesk.Name = "lblDesk";
            this.lblDesk.Size = new System.Drawing.Size(64, 16);
            this.lblDesk.TabIndex = 3;
            this.lblDesk.Text = "Deskripsi";
            // 
            // lblPemilik
            // 
            this.lblPemilik.AutoSize = true;
            this.lblPemilik.Location = new System.Drawing.Point(233, 188);
            this.lblPemilik.Name = "lblPemilik";
            this.lblPemilik.Size = new System.Drawing.Size(91, 16);
            this.lblPemilik.TabIndex = 4;
            this.lblPemilik.Text = "Nama Pemilik";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(370, 45);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(237, 22);
            this.txtNama.TabIndex = 5;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(370, 118);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(237, 22);
            this.txtAlamat.TabIndex = 6;
            // 
            // txtDesk
            // 
            this.txtDesk.Location = new System.Drawing.Point(370, 151);
            this.txtDesk.Name = "txtDesk";
            this.txtDesk.Size = new System.Drawing.Size(237, 22);
            this.txtDesk.TabIndex = 7;
            // 
            // cmbJenis
            // 
            this.cmbJenis.FormattingEnabled = true;
            this.cmbJenis.Location = new System.Drawing.Point(642, -93);
            this.cmbJenis.Name = "cmbJenis";
            this.cmbJenis.Size = new System.Drawing.Size(237, 24);
            this.cmbJenis.TabIndex = 8;
            // 
            // cmbPemilik
            // 
            this.cmbPemilik.FormattingEnabled = true;
            this.cmbPemilik.Location = new System.Drawing.Point(370, 186);
            this.cmbPemilik.Name = "cmbPemilik";
            this.cmbPemilik.Size = new System.Drawing.Size(237, 24);
            this.cmbPemilik.TabIndex = 9;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(222, 226);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 10;
            this.btnTambah.Text = "Insert";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(329, 226);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 11;
            this.btnUbah.Text = "Update";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(439, 226);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Delete";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(543, 226);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvUMKM
            // 
            this.dgvUMKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUMKM.EnableHeadersVisualStyles = false;
            this.dgvUMKM.Location = new System.Drawing.Point(212, 304);
            this.dgvUMKM.Name = "dgvUMKM";
            this.dgvUMKM.RowHeadersWidth = 51;
            this.dgvUMKM.RowTemplate.Height = 24;
            this.dgvUMKM.Size = new System.Drawing.Size(419, 136);
            this.dgvUMKM.TabIndex = 14;
            this.dgvUMKM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUMKM_CellContentClick);
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(222, 278);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(114, 16);
            this.lblCari.TabIndex = 15;
            this.lblCari.Text = "Cari Nama Usaha";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(356, 274);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(172, 22);
            this.txtCari.TabIndex = 16;
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(543, 275);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 23);
            this.btnCari.TabIndex = 17;
            this.btnCari.Text = "Search";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(370, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 24);
            this.comboBox1.TabIndex = 18;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(233, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(60, 16);
            this.lblID.TabIndex = 19;
            this.lblID.Text = "IDUMKM";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(370, 16);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(237, 22);
            this.txtID.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "<- Kembali ke Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formUMKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.lblCari);
            this.Controls.Add(this.dgvUMKM);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.cmbPemilik);
            this.Controls.Add(this.cmbJenis);
            this.Controls.Add(this.txtDesk);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblPemilik);
            this.Controls.Add(this.lblDesk);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.lblJenis);
            this.Controls.Add(this.lblNama);
            this.Name = "formUMKM";
            this.Text = "formUMKM";
            this.Load += new System.EventHandler(this.formUMKM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUMKM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblJenis;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblDesk;
        private System.Windows.Forms.Label lblPemilik;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtDesk;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.ComboBox cmbPemilik;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvUMKM;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button button1;
    }
}