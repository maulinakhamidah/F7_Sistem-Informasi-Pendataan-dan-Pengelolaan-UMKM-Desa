namespace ProjekPABD
{
    partial class FormPemilik
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pemilikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uMKM_DesaDataSet = new ProjekPABD.UMKM_DesaDataSet();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNomor = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvPemilik = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnKembali = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pemilikTableAdapter = new ProjekPABD.UMKM_DesaDataSetTableAdapters.PemilikTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pemilikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemilik)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(180, 76);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(200, 26);
            this.txtID.TabIndex = 4;
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
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(180, 116);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(200, 26);
            this.txtNama.TabIndex = 5;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(180, 156);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(200, 26);
            this.txtAlamat.TabIndex = 6;
            // 
            // txtNomor
            // 
            this.txtNomor.Location = new System.Drawing.Point(180, 196);
            this.txtNomor.Name = "txtNomor";
            this.txtNomor.Size = new System.Drawing.Size(200, 26);
            this.txtNomor.TabIndex = 7;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(420, 76);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 26);
            this.btnSimpan.TabIndex = 8;
            this.btnSimpan.Text = "Insert";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(420, 116);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 26);
            this.btnUbah.TabIndex = 9;
            this.btnUbah.Text = "Update";
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(420, 156);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 26);
            this.btnHapus.TabIndex = 10;
            this.btnHapus.Text = "Delete";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(420, 196);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvPemilik
            // 
            this.dgvPemilik.ColumnHeadersHeight = 29;
            this.dgvPemilik.Location = new System.Drawing.Point(40, 246);
            this.dgvPemilik.Name = "dgvPemilik";
            this.dgvPemilik.RowHeadersWidth = 51;
            this.dgvPemilik.Size = new System.Drawing.Size(550, 180);
            this.dgvPemilik.TabIndex = 12;
            this.dgvPemilik.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPemilik_CellClick);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 13;
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(0, 0);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(75, 23);
            this.btnKembali.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Pemilik (Auto)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Pemilik";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alamat Pemilik";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "No Kontak";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "<- Kembali ke Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pemilikTableAdapter
            // 
            this.pemilikTableAdapter.ClearBeforeFill = true;
            // 
            // FormPemilik
            // 
            this.ClientSize = new System.Drawing.Size(750, 548);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNomor);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvPemilik);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnKembali);
            this.Name = "FormPemilik";
            this.Text = "Kelola Data Pemilik";
            this.Load += new System.EventHandler(this.FormPemilik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pemilikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMKM_DesaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemilik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtID, txtNama, txtAlamat, txtNomor;
        private System.Windows.Forms.Button btnSimpan, btnUbah, btnHapus, btnClear, btnKembali;
        private System.Windows.Forms.DataGridView dgvPemilik;
        private System.Windows.Forms.Label lblTotal, label1, label2, label3, label4;
        private System.Windows.Forms.Button button1;
        private UMKM_DesaDataSet uMKM_DesaDataSet;
        private System.Windows.Forms.BindingSource pemilikBindingSource;
        private UMKM_DesaDataSetTableAdapters.PemilikTableAdapter pemilikTableAdapter;
    }
}