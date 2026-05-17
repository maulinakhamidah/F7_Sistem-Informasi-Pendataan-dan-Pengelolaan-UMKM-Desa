using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions; // WAJIB: Untuk validasi Regex
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class FormPemilik : Form
    {
        // Menyinkronkan DataSource sesuai server lokal terupdate milikmu
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        // Deklarasi Komponen Sinkronisasi Data Binding (Poin 4 & 5)
        private BindingSource bSource = new BindingSource();
        private DataTable dtPemilik = new DataTable();

        public FormPemilik()
        {
            InitializeComponent();
        }

        private void FormPemilik_Load(object sender, EventArgs e)
        {
            TampilkanDataDenganView();
            AturBindingKomponen();
            HitungTotal();

            // KUNCI GRIDVIEW AGAR TIDAK BISA DIKETIK MANUAL
            dgvPemilik.ReadOnly = true;          // Melarang user mengubah isi sel
            dgvPemilik.AllowUserToAddRows = false; // Menghilangkan baris kosong bertanda bintang (*) di paling bawah
            dgvPemilik.AllowUserToDeleteRows = false; // Melarang user menghapus baris lewat tombol Delete keyboard
        }

        // 1. SELECT DATA: Mengubah query dasar menjadi VIEW (Poin 2)
        private void TampilkanDataDenganView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Memanggil objek VIEW 'vwPemilikPublic' yang dibuat di database
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM vwPemilikPublic", conn);
                    dtPemilik.Clear();
                    sda.Fill(dtPemilik);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Tampil View: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. DATA BINDING SINKRONISASI: Memanfaatkan BindingSource & BindingNavigator (Poin 4 & 5)
        // 2. DATA BINDING SINKRONISASI: Memanfaatkan BindingSource & BindingNavigator
    }
}