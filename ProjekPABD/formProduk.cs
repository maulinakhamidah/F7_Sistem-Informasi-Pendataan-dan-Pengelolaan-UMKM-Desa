using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formProduk : Form
    {
        // Connection string sesuai milikmu
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-66MU6CLK\\MAULINAA; Initial Catalog=UMKM_Desa;Integrated Security=True");

        public formProduk()
        {
            InitializeComponent();
        }

        private void formProduk_Load(object sender, EventArgs e)
        {
            // Proteksi Awal: Kunci grid agar aman tidak bisa diketik asal oleh user
            dgvProduk.ReadOnly = true;
            dgvProduk.AllowUserToAddRows = false;
            dgvProduk.AllowUserToDeleteRows = false;

            // 1. Mengisi ComboBox otomatis lewat dataset bawaan desainer kamu
            try
            {
                this.uMKMTableAdapter.Fill(this.uMKM_DesaDataSet1.UMKM);
            }
            catch (Exception ex) { MessageBox.Show("Gagal Load Data UMKM Ke Dropdown: " + ex.Message); }

            // 2. Tampilkan data utama produk menggunakan VIEW
            TampilkanData();
        }

        // Tampilkan data produk memanfaatkan VIEW 'vwProdukPublic'
        private void TampilkanData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "SELECT * FROM vwProdukPublic";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Masukkan data hasil VIEW ke produkBindingSource milik desainer
                produkBindingSource.DataSource = dt;
                dgvProduk.DataSource = produkBindingSource;

                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Memuat Data View: " + ex.Message); }
        }

        // Sinkronisasi ulang binding komponen setelah layar dibersihkan
        private void AturBindingKomponen()
        {
            txtID.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            txtHarga.DataBindings.Clear();
            txtStok.DataBindings.Clear();
            cmbUMKM.DataBindings.Clear();

            // Pasang kembali sesuai konfigurasi awal desainer kamu
            txtID.DataBindings.Add("Text", produkBindingSource, "IDProduk", true);
            txtNama.DataBindings.Add("Text", produkBindingSource, "NamaProduk", true);
            txtHarga.DataBindings.Add("Text", produkBindingSource, "Harga", true);
            txtStok.DataBindings.Add("Text", produkBindingSource, "Stok", true);
            cmbUMKM.DataBindings.Add("SelectedValue", produkBindingSource, "IDUMKM", true);
        }

        // INSERT (Dijalankan saat tombol 'btntambah' diklik)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtNama.Text.Trim(), @"^[a-zA-Z0-9 ]+$"))
            {
                MessageBox.Show("Nama Produk hanya boleh berisi huruf, angka, dan spasi!", "Peringatan");
                return;
            }

            int harga;
            if (!int.TryParse(txtHarga.Text, out harga) || harga < 0)
            {
                MessageBox.Show("Harga harus diisi dengan angka positif!", "Peringatan");
                return;
            }

            int stok;
            if (!int.TryParse(txtStok.Text, out stok) || stok < 0)
            {
                MessageBox.Show("Stok harus diisi dengan angka positif!", "Peringatan");
                return;
            }

            if (cmbUMKM.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih UMKM terlebih dahulu!", "Peringatan");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_InsertProduk", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaProduk", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Harga", harga);
                    cmd.Parameters.AddWithValue("@Stok", stok);
                    cmd.Parameters.AddWithValue("@IDUMKM", cmbUMKM.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                MessageBox.Show("Data Produk Berhasil Disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanData();
                BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan SP: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // UPDATE (Dijalankan saat tombol 'btnUbah' diklik)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Pilih data produk yang ingin diubah pada tabel!", "Peringatan");
                return;
            }

            int harga, stok;
            if (!int.TryParse(txtHarga.Text, out harga) || !int.TryParse(txtStok.Text, out stok))
            {
                MessageBox.Show("Harga dan Stok harus berupa angka valid!", "Peringatan");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduk", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProduk", Convert.ToInt32(txtID.Text));
                    cmd.Parameters.AddWithValue("@NamaProduk", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Harga", harga);
                    cmd.Parameters.AddWithValue("@Stok", stok);
                    cmd.Parameters.AddWithValue("@IDUMKM", cmbUMKM.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                MessageBox.Show("Data Produk Berhasil Diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update SP: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // DELETE (Dijalankan saat tombol 'btnHapus' diklik)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Pilih data produk yang ingin dihapus pada tabel!", "Peringatan");
                return;
            }

            if (MessageBox.Show("Apakah Anda yakin ingin menghapus produk ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_DeleteProduk", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDProduk", Convert.ToInt32(txtID.Text));

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                    MessageBox.Show("Produk Berhasil Dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanData();
                    BersihkanLayar();
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus SP: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
            }
        }

        // Berfungsi menangani perpindahan baris di GridView (Terikat ke event CellEnter di desainer)
        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProduk.Rows.Count)
            {
                // Jika ikatan data terputus akibat tombol Clear, sambungkan lagi di sini
                if (txtNama.DataBindings.Count == 0)
                {
                    AturBindingKomponen();
                }

                // Ubah posisi pointer BindingSource agar Textbox ikut ter-update otomatis
                produkBindingSource.Position = e.RowIndex;
            }
        }

        private void BersihkanLayar()
        {
            // Lepas sementara ikatan data agar inputan teks murni kosong tanpa error binding
            txtID.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            txtHarga.DataBindings.Clear();
            txtStok.DataBindings.Clear();
            cmbUMKM.DataBindings.Clear();

            // Kosongkan manual
            txtID.Clear();
            txtNama.Clear();
            txtHarga.Clear();
            txtStok.Clear();
            cmbUMKM.SelectedIndex = -1;

            txtNama.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            BersihkanLayar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tombol kembali ke Menu Utama (Form2)
            Form2 menuUtama = new Form2();
            menuUtama.Show();
            this.Close();
        }

        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sengaja dikosongkan karena logika klik datanya sudah diurus otomatis oleh CellEnter (dgvProduk_CellClick)
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
        }
    }
}