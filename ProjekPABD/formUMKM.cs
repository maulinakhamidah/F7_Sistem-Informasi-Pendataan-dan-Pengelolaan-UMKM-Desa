using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formUMKM : Form
    {
        // Menyinkronkan DataSource sesuai server lokal terupdate milikmu
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        // Deklarasi Komponen Sinkronisasi Data Binding (Poin 4 & 5)
        private BindingSource bSource = new BindingSource();
        private DataTable dtUMKM = new DataTable();

        public formUMKM()
        {
            InitializeComponent();
        }

        private void formUMKM_Load(object sender, EventArgs e)
        {
            // Load data dasar untuk ComboBox Pemilik terlebih dahulu
            LoadComboPemilik();
            IsiKategoriUsaha();

            // Jalankan sinkronisasi komponen arsitektur View dan Data Binding
            TampilkanDataDenganView();
            AturBindingKomponen();

            dgvUMKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtID.ReadOnly = true; // ID menggunakan IDENTITY, tidak boleh diubah manual
            dgvUMKM.ReadOnly = true;
            dgvUMKM.AllowUserToAddRows = false;
            dgvUMKM.AllowUserToDeleteRows = false;
        }

        // 1. SELECT DATA: Mengubah query dasar menjadi VIEW (Poin 2)
        private void TampilkanDataDenganView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Memanggil objek VIEW 'vw_UMKM_Detail' yang dibuat di database
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vwUMKMPublic", conn);

                    dtUMKM.Clear();
                    sda.Fill(dtUMKM);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Tampil View: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. DATA BINDING SINKRONISASI: Memanfaatkan BindingSource & BindingNavigator (Poin 4 & 5)
        private void AturBindingKomponen()
        {
            // Menghubungkan kaitan data berantai ke grid view
            bSource.DataSource = dtUMKM;
            dgvUMKM.DataSource = bSource;

            // Mengaitkan struktur ke komponen kontrol navigator visual di form
            if (bindingNavigator1 != null)
            {
                bindingNavigator1.BindingSource = bSource;
            }

            // Bersihkan sisa ikatan properti data lama mencegah konflik redundansi objek form
            txtID.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtDesk.DataBindings.Clear();
            cmbPemilik.DataBindings.Clear();

            // Menerapkan penalian data otomatis (Data Binding) ke elemen komponen teks/combo visual
            txtID.DataBindings.Add("Text", bSource, "IDUMKM", true);
            txtNama.DataBindings.Add("Text", bSource, "NamaUsaha", true);
            comboBox1.DataBindings.Add("Text", bSource, "JenisUsaha", true);
            txtAlamat.DataBindings.Add("Text", bSource, "AlamatUsaha", true);
            txtDesk.DataBindings.Add("Text", bSource, "DeskripsiUsaha", true);
            cmbPemilik.DataBindings.Add("SelectedValue", bSource, "IDPemilik", true);

            // Sembunyikan kolom IDPemilik agar DataGridView terlihat bersih dan rapi
            if (dgvUMKM.Columns["IDPemilik"] != null)
                dgvUMKM.Columns["IDPemilik"].Visible = false;
        }

        private void LoadComboPemilik()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT IDPemilik, NamaPemilik FROM Pemilik", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    cmbPemilik.DataSource = dt;
                    cmbPemilik.DisplayMember = "NamaPemilik";
                    cmbPemilik.ValueMember = "IDPemilik";
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load data pemilik: " + ex.Message); }
        }

        private void IsiKategoriUsaha()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Kuliner");
            comboBox1.Items.Add("Kerajinan");
            comboBox1.Items.Add("Perdagangan");
            comboBox1.Items.Add("Jasa");
            comboBox1.SelectedIndex = 0;
        }

        // 3. INSERT DATA: Memanfaatkan STORED PROCEDURE (Poin 1)
       
    }
}