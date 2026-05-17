using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formProduk : Form
    {
        // Gunakan connection string yang sama dengan form lainnya
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-66MU6CLK\\MAULINAA; Initial Catalog=UMKM_Desa;Integrated Security=True");

        public formProduk()
        {
            InitializeComponent();
        }

        private void formProduk_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uMKM_DesaDataSet1.UMKM' table. You can move, or remove it, as needed.
            this.uMKMTableAdapter.Fill(this.uMKM_DesaDataSet1.UMKM);
            // TODO: This line of code loads data into the 'uMKM_DesaDataSet2.Produk' table. You can move, or remove it, as needed.
            this.produkTableAdapter.Fill(this.uMKM_DesaDataSet2.Produk);
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
            // 1. Cek Nama Produk (Mencegah error SQL Constraint)
            // Regex ini memastikan hanya huruf dan spasi yang boleh masuk
            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Nama Produk hanya boleh berisi huruf dan spasi!", "Peringatan");
                return;
            }

            // 1. Validasi HARGA
            int harga;
            if (!int.TryParse(txtHarga.Text, out harga))
            {
                MessageBox.Show("Harga harus diisi dengan angka saja!", "Peringatan");
                return;
            }

            // 2. Validasi STOK
            int stok;
            if (!int.TryParse(txtStok.Text, out stok))
            {
                MessageBox.Show("Stok harus diisi dengan angka saja!", "Peringatan");
                return;
            }

            // 3. Jika lolos semua, baru masuk ke blok try-catch SQL
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query INSERT (IDProduk tidak perlu dimasukkan karena Auto-Increment/Identity)
                string query = "INSERT INTO Produk (NamaProduk, Harga, Stok, IDUMKM) VALUES (@nama, @harga, @stok, @idumkm)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@harga", harga); // Mengambil variabel hasil TryParse
                cmd.Parameters.AddWithValue("@stok", stok);   // Mengambil variabel hasil TryParse
                cmd.Parameters.AddWithValue("@idumkm", cmbUMKM.SelectedValue); // Mengambil ID dari ComboBox

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data Produk Berhasil Disimpan!", "Sukses");
                TampilkanData(); // Refresh tabel
                BersihkanLayar(); // Kosongkan form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
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
                txtID.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value.ToString();
                txtHarga.Text = row.Cells[2].Value.ToString();
                txtStok.Text = row.Cells[3].Value.ToString();
                cmbUMKM.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}