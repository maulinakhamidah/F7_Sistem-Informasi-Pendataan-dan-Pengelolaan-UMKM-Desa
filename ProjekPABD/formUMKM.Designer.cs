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
            this.components = new System.ComponentModel.Container();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblJenis = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblDesk = new System.Windows.Forms.Label();
            this.lblPemilik = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.uMKMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uMKM_DesaDataSet1 = new ProjekPABD.UMKM_DesaDataSet1();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtDesk = new System.Windows.Forms.TextBox();
            this.cmbJenis = new System.Windows.Forms.ComboBox();
            this.cmbPemilik = new System.Windows.Forms.ComboBox();
            this.pemilikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uMKM_DesaDataSet = new ProjekPABD.UMKM_DesaDataSet();
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
            this.uMKMTableAdapter = new ProjekPABD.UMKM_DesaDataSet1TableAdapters.UMKMTableAdapter();
            this.pemilikTableAdapter = new ProjekPABD.UMKM_DesaDataSetTableAdapters.PemilikTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uMKMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pemilikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUMKM)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(106, 124);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(102, 20);
            this.lblNama.TabIndex = 0;
            this.lblNama.Text = "Nama Usaha";
            // 
            // lblJenis
            // 
            this.lblJenis.AutoSize = true;
            this.lblJenis.Location = new System.Drawing.Point(106, 167);
            this.lblJenis.Name = "lblJenis";
            this.lblJenis.Size = new System.Drawing.Size(97, 20);
            this.lblJenis.TabIndex = 1;
            this.lblJenis.Text = "Jenis Usaha";
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(106, 214);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(59, 20);
            this.lblAlamat.TabIndex = 2;
            this.lblAlamat.Text = "Alamat";
            // 
            // lblDesk
            // 
            this.lblDesk.AutoSize = true;
            this.lblDesk.Location = new System.Drawing.Point(106, 257);
            this.lblDesk.Name = "lblDesk";
            this.lblDesk.Size = new System.Drawing.Size(74, 20);
            this.lblDesk.TabIndex = 3;
            this.lblDesk.Text = "Deskripsi";
            // 
            // lblPemilik
            // 
            this.lblPemilik.AutoSize = true;
            this.lblPemilik.Location = new System.Drawing.Point(106, 301);
            this.lblPemilik.Name = "lblPemilik";
            this.lblPemilik.Size = new System.Drawing.Size(104, 20);
            this.lblPemilik.TabIndex = 4;
            this.lblPemilik.Text = "Nama Pemilik";
            // 
            // txtNama
            // 
            this.txtNama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uMKMBindingSource, "NamaUsaha", true));
            this.txtNama.Location = new System.Drawing.Point(260, 122);
            this.txtNama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(266, 26);
            this.txtNama.TabIndex = 5;
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
            // txtAlamat
            // 
            this.txtAlamat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uMKMBindingSource, "AlamatUsaha", true));
            this.txtAlamat.Location = new System.Drawing.Point(260, 214);
            this.txtAlamat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(266, 26);
            this.txtAlamat.TabIndex = 6;
            // 
            // txtDesk
            // 
            this.txtDesk.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uMKMBindingSource, "DeskripsiUsaha", true));
            this.txtDesk.Location = new System.Drawing.Point(260, 255);
            this.txtDesk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesk.Name = "txtDesk";
            this.txtDesk.Size = new System.Drawing.Size(266, 26);
            this.txtDesk.TabIndex = 7;
            // 
            // cmbJenis
            // 
            this.cmbJenis.FormattingEnabled = true;
            this.cmbJenis.Location = new System.Drawing.Point(722, -116);
            this.cmbJenis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbJenis.Name = "cmbJenis";
            this.cmbJenis.Size = new System.Drawing.Size(266, 28);
            this.cmbJenis.TabIndex = 8;
            // 
            // cmbPemilik
            // 
            this.cmbPemilik.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.uMKMBindingSource, "IDPemilik", true));
            this.cmbPemilik.DataSource = this.pemilikBindingSource;
            this.cmbPemilik.DisplayMember = "NamaPemilik";
            this.cmbPemilik.FormattingEnabled = true;
            this.cmbPemilik.Location = new System.Drawing.Point(260, 298);
            this.cmbPemilik.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPemilik.Name = "cmbPemilik";
            this.cmbPemilik.Size = new System.Drawing.Size(266, 28);
            this.cmbPemilik.TabIndex = 9;
            this.cmbPemilik.ValueMember = "IDPemilik";
            // 
            // pemilikBindingSource
            // 
            this.pemilikBindingSource.DataMember = "Pemilik";
            this.pemilikBindingSource.DataSource = this.uMKM_DesaDataSet;
            // 
            // uMKM_DesaDataSet
            // 
            this.uMKM_DesaDataSet.DataSetName = "UMKM_DesaDataSet";
            this.uMKM_DesaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(631, 104);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(84, 29);
            this.btnTambah.TabIndex = 10;
            this.btnTambah.Text = "Insert";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(631, 167);
            this.btnUbah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(84, 29);
            this.btnUbah.TabIndex = 11;
            this.btnUbah.Text = "Update";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(631, 239);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(84, 29);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Delete";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(631, 314);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 29);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvUMKM
            // 
            this.dgvUMKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUMKM.EnableHeadersVisualStyles = false;
            this.dgvUMKM.Location = new System.Drawing.Point(58, 405);
            this.dgvUMKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvUMKM.Name = "dgvUMKM";
            this.dgvUMKM.RowHeadersWidth = 51;
            this.dgvUMKM.RowTemplate.Height = 24;
            this.dgvUMKM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUMKM.Size = new System.Drawing.Size(723, 265);
            this.dgvUMKM.TabIndex = 14;
            this.dgvUMKM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUMKM_CellClick);
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(105, 372);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(134, 20);
            this.lblCari.TabIndex = 15;
            this.lblCari.Text = "Cari Nama Usaha";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(255, 366);
            this.txtCari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(193, 26);
            this.txtCari.TabIndex = 16;
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(466, 368);
            this.btnCari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(84, 29);
            this.btnCari.TabIndex = 17;
            this.btnCari.Text = "Search";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uMKMBindingSource, "JenisUsaha", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(260, 167);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(266, 28);
            this.comboBox1.TabIndex = 18;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(106, 90);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 20);
            this.lblID.TabIndex = 19;
            this.lblID.Text = "IDUMKM";
            // 
            // txtID
            // 
            this.txtID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uMKMBindingSource, "IDUMKM", true));
            this.txtID.Location = new System.Drawing.Point(260, 86);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(266, 26);
            this.txtID.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 678);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "<- Kembali ke Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uMKMTableAdapter
            // 
            this.uMKMTableAdapter.ClearBeforeFill = true;
            // 
            // pemilikTableAdapter
            // 
            this.pemilikTableAdapter.ClearBeforeFill = true;
            // 
            // formUMKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 714);
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
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uMKMBindingSource, "AlamatUsaha", true));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formUMKM";
            this.Text = "formUMKM";
            this.Load += new System.EventHandler(this.formUMKM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uMKMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pemilikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet)).EndInit();
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
        private UMKM_DesaDataSet1 uMKM_DesaDataSet1;
        private System.Windows.Forms.BindingSource uMKMBindingSource;
        private UMKM_DesaDataSet1TableAdapters.UMKMTableAdapter uMKMTableAdapter;
        private UMKM_DesaDataSet uMKM_DesaDataSet;
        private System.Windows.Forms.BindingSource pemilikBindingSource;
        private UMKM_DesaDataSetTableAdapters.PemilikTableAdapter pemilikTableAdapter;
    }

}