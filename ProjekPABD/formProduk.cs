using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formProduk : Form
    {
        // Gunakan connection string yang sama dengan form lainnya
        SqlConnection conn = new SqlConnection("Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public formProduk()
        {
            InitializeComponent();
        }

        private void formProduk_Load(object sender, EventArgs e)
        {
            TampilkanData();
            LoadComboUMKM(); // Mengisi dropdown Pilih UMKM
        }

        // Tampilkan Data Produk dengan JOIN ke tabel UMKM
        private void TampilkanData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = @"SELECT p.IDProduk, p.NamaProduk, p.Harga, p.Stok, u.NamaUsaha 
                                 FROM Produk p 
                                 JOIN UMKM u ON p.IDUMKM = u.IDUMKM";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvProduk.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Tampil: " + ex.Message); }
        }

        // Mengambil daftar UMKM untuk ComboBox
        private void LoadComboUMKM()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDUMKM, NamaUsaha FROM UMKM", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cmbUMKM.DataSource = dt;
                cmbUMKM.DisplayMember = "NamaUsaha"; // Nama UMKM yang tampil
                cmbUMKM.ValueMember = "IDUMKM";      // ID yang disimpan ke DB
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Load UMKM: " + ex.Message); conn.Close(); }
        }

        // INSERT (Tombol Simpan Produk)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Produk (NamaProduk, Harga, Stok, IDUMKM) 
                                                VALUES (@nama, @harga, @stok, @idumkm)", conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@harga", txtHarga.Text);
                cmd.Parameters.AddWithValue("@stok", txtStok.Text);
                cmd.Parameters.AddWithValue("@idumkm", cmbUMKM.SelectedValue);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Produk Berhasil Ditambahkan!");
                TampilkanData();
                BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); conn.Close(); }
        }

        // UPDATE (Tombol Ubah Produk)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Asumsi ada TextBox tersembunyi atau label untuk simpan IDProduk bernama txtIDProduk
            if (string.IsNullOrEmpty(txtID.Text)) return;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE Produk SET NamaProduk=@nama, Harga=@harga, 
                                                Stok=@stok, IDUMKM=@idumkm WHERE IDProduk=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@harga", txtHarga.Text);
                cmd.Parameters.AddWithValue("@stok", txtStok.Text);
                cmd.Parameters.AddWithValue("@idumkm", cmbUMKM.SelectedValue);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Produk Berhasil Diperbarui!");
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); conn.Close(); }
        }

        // DELETE (Tombol Hapus Produk)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Produk WHERE IDProduk=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Produk Berhasil Dihapus!");
                TampilkanData();
                BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); conn.Close(); }
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];
                // Sesuaikan nama kolom GridView dengan query SELECT di atas
                txtID.Text = row.Cells["IDProduk"].Value.ToString();
                txtNama.Text = row.Cells["NamaProduk"].Value.ToString();
                txtHarga.Text = row.Cells["Harga"].Value.ToString();
                txtStok.Text = row.Cells["Stok"].Value.ToString();
                cmbUMKM.Text = row.Cells["NamaUsaha"].Value.ToString();
            }
        }

        private void BersihkanLayar()
        {
            txtID.Clear();
            txtNama.Clear();
            txtHarga.Clear();
            txtStok.Clear();
            cmbUMKM.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e) { BersihkanLayar(); }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Menampilkan kembali Form Menu Utama (Form2)
            Form2 menuUtama = new Form2();
            menuUtama.Show();

            // Menutup form yang sekarang sedang dibuka
            this.Close();
        }

        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil baris yang diklik
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];

                // Pindahkan data dari kolom tabel ke TextBox di atas
                // Sesuaikan nama kolom "IDUMKM", "NamaUsaha", dll dengan nama di database kamu
                txtID.Text = row.Cells["IDUMKM"].Value.ToString();
                txtNama.Text = row.Cells["NamaUsaha"].Value.ToString();
                txtHarga.Text = row.Cells["JenisUsaha"].Value.ToString();
                txtStok.Text = row.Cells["AlamatUsaha"].Value.ToString();
                cmbUMKM.Text = row.Cells["DeskripsiUsaha"].Value.ToString();
            }
        }
    }
}