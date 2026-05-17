namespace ProjekPABD
{
    partial class formProduk
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
            this.components = new System.ComponentModel.Container();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.produkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uMKM_DesaDataSet2 = new ProjekPABD.UMKM_DesaDataSet2();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblHarga = new System.Windows.Forms.Label();
            this.lblStok = new System.Windows.Forms.Label();
            this.cmbUMKM = new System.Windows.Forms.ComboBox();
            this.uMKMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uMKM_DesaDataSet1 = new ProjekPABD.UMKM_DesaDataSet1();
            this.btntambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvProduk = new System.Windows.Forms.DataGridView();
            this.lblPilih = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.produkTableAdapter = new ProjekPABD.UMKM_DesaDataSet2TableAdapters.ProdukTableAdapter();
            this.uMKMTableAdapter = new ProjekPABD.UMKM_DesaDataSet1TableAdapters.UMKMTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.produkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produkBindingSource, "NamaProduk", true));
            this.txtNama.Location = new System.Drawing.Point(212, 94);
            this.txtNama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(248, 26);
            this.txtNama.TabIndex = 0;
            // 
            // produkBindingSource
            // 
            this.produkBindingSource.DataMember = "Produk";
            this.produkBindingSource.DataSource = this.uMKM_DesaDataSet2;
            // 
            // uMKM_DesaDataSet2
            // 
            this.uMKM_DesaDataSet2.DataSetName = "UMKM_DesaDataSet2";
            this.uMKM_DesaDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtHarga
            // 
            this.txtHarga.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produkBindingSource, "Harga", true));
            this.txtHarga.Location = new System.Drawing.Point(212, 143);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(248, 26);
            this.txtHarga.TabIndex = 2;
            // 
            // txtStok
            // 
            this.txtStok.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produkBindingSource, "Stok", true));
            this.txtStok.Location = new System.Drawing.Point(212, 193);
            this.txtStok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(248, 26);
            this.txtStok.TabIndex = 3;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(28, 97);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(105, 20);
            this.lblNama.TabIndex = 4;
            this.lblNama.Text = "Nama Produk";
            // 
            // lblHarga
            // 
            this.lblHarga.AutoSize = true;
            this.lblHarga.Location = new System.Drawing.Point(28, 142);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(53, 20);
            this.lblHarga.TabIndex = 5;
            this.lblHarga.Text = "Harga";
            // 
            // lblStok
            // 
            this.lblStok.AutoSize = true;
            this.lblStok.Location = new System.Drawing.Point(28, 192);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(42, 20);
            this.lblStok.TabIndex = 6;
            this.lblStok.Text = "Stok";
            // 
            // cmbUMKM
            // 
            this.cmbUMKM.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produkBindingSource, "IDUMKM", true));
            this.cmbUMKM.DataSource = this.uMKMBindingSource;
            this.cmbUMKM.DisplayMember = "NamaUsaha";
            this.cmbUMKM.FormattingEnabled = true;
            this.cmbUMKM.Location = new System.Drawing.Point(212, 241);
            this.cmbUMKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUMKM.Name = "cmbUMKM";
            this.cmbUMKM.Size = new System.Drawing.Size(248, 28);
            this.cmbUMKM.TabIndex = 7;
            this.cmbUMKM.ValueMember = "IDUMKM";
            // 
            // uMKMBindingSource
            // 
            this.uMKMBindingSource.DataMember = "UMKM";
            this.uMKMBindingSource.DataSource = this.uMKM_DesaDataSet1;
            // 
            // uMKM_DesaDataSet1
            // 
            this.uMKM_DesaDataSet1.DataSetName = "UMKM_DesaDataSet1";
            this.uMKM_DesaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btntambah
            // 
            this.btntambah.Location = new System.Drawing.Point(549, 63);
            this.btntambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntambah.Name = "btntambah";
            this.btntambah.Size = new System.Drawing.Size(84, 29);
            this.btntambah.TabIndex = 8;
            this.btntambah.Text = "Insert";
            this.btntambah.UseVisualStyleBackColor = true;
            this.btntambah.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(549, 124);
            this.btnUbah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(84, 29);
            this.btnUbah.TabIndex = 9;
            this.btnUbah.Text = "Update";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(549, 183);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(84, 29);
            this.btnHapus.TabIndex = 10;
            this.btnHapus.Text = "Delete";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvProduk
            // 
            this.dgvProduk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduk.Location = new System.Drawing.Point(73, 309);
            this.dgvProduk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.RowHeadersWidth = 51;
            this.dgvProduk.RowTemplate.Height = 24;
            this.dgvProduk.Size = new System.Drawing.Size(523, 206);
            this.dgvProduk.TabIndex = 11;
            this.dgvProduk.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduk_CellContentClick);
            this.dgvProduk.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduk_CellClick);
            // 
            // lblPilih
            // 
            this.lblPilih.AutoSize = true;
            this.lblPilih.Location = new System.Drawing.Point(28, 246);
            this.lblPilih.Name = "lblPilih";
            this.lblPilih.Size = new System.Drawing.Size(89, 20);
            this.lblPilih.TabIndex = 12;
            this.lblPilih.Text = "Pilih UMKM";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(549, 237);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(29, 63);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(76, 20);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "IDProduk";
            // 
            // txtID
            // 
            this.txtID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produkBindingSource, "IDProduk", true));
            this.txtID.Location = new System.Drawing.Point(212, 60);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(248, 26);
            this.txtID.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 523);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "<- Kembali ke Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // produkTableAdapter
            // 
            this.produkTableAdapter.ClearBeforeFill = true;
            // 
            // uMKMTableAdapter
            // 
            this.uMKMTableAdapter.ClearBeforeFill = true;
            // 
            // formProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 565);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblPilih);
            this.Controls.Add(this.dgvProduk);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btntambah);
            this.Controls.Add(this.cmbUMKM);
            this.Controls.Add(this.lblStok);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtNama);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formProduk";
            this.Text = "formProduk";
            this.Load += new System.EventHandler(this.formProduk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.ComboBox cmbUMKM;
        private System.Windows.Forms.Button btntambah;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvProduk;
        private System.Windows.Forms.Label lblPilih;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button button1;
        private UMKM_DesaDataSet2 uMKM_DesaDataSet2;
        private System.Windows.Forms.BindingSource produkBindingSource;
        private UMKM_DesaDataSet2TableAdapters.ProdukTableAdapter produkTableAdapter;
        private UMKM_DesaDataSet1 uMKM_DesaDataSet1;
        private System.Windows.Forms.BindingSource uMKMBindingSource;
        private UMKM_DesaDataSet1TableAdapters.UMKMTableAdapter uMKMTableAdapter;
    }
}