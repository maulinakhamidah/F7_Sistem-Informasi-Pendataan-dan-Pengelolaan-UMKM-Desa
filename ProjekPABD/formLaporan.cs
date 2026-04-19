using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formLaporan : Form
    {
        // 1. Tambahkan deklarasi koneksi di sini agar variabel 'conn' dikenali
        SqlConnection conn = new SqlConnection("Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public formLaporan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 menuUtama = new Form2();
            menuUtama.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private void formLaporan_Load(object sender, EventArgs e)
        {
            TampilkanLaporan();
        }

        private void TampilkanLaporan()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"SELECT p.NamaPemilik, u.NamaUsaha, u.JenisUsaha, u.AlamatUsaha, 
                                pr.NamaProduk, pr.Harga, pr.Stok
                                FROM Pemilik p
                                JOIN UMKM u ON p.IDPemilik = u.IDPemilik
                                JOIN Produk pr ON u.IDUMKM = pr.IDUMKM";

                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dgvLaporan.DataSource = dt;

                // 2. Tambahan agar kolom tabel otomatis menyesuaikan lebar teks
                dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 3. Membuat tabel hanya bisa dibaca (ReadOnly)
                dgvLaporan.ReadOnly = true;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Laporan: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }
}