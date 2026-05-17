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
        private void AturBindingKomponen()
        {
            // Sinkronisasikan datasource utama ke binding source bawaan designer
            pemilikBindingSource.DataSource = dtPemilik;
            dgvPemilik.DataSource = pemilikBindingSource;

            // Kaitkan ke komponen navigator visual di form
            if (bindingNavigator1 != null)
            {
                bindingNavigator1.BindingSource = pemilikBindingSource;
            }

            // Bersihkan sisa ikatan properti data lama mencegah konflik redundansi
            txtID.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtNomor.DataBindings.Clear();

            // Menerapkan penalian data otomatis (Data Binding) yang benar dan akurat
            txtID.DataBindings.Add("Text", pemilikBindingSource, "IDPemilik", true);
            txtNama.DataBindings.Add("Text", pemilikBindingSource, "NamaPemilik", true); // <-- PERBAIKAN: Diubah ke NamaPemilik
            txtAlamat.DataBindings.Add("Text", pemilikBindingSource, "AlamatPemilik", true);
            txtNomor.DataBindings.Add("Text", pemilikBindingSource, "NoKontak", true);
        }

        // Event pendeteksi klik pada sel DataGridView untuk menyamakan posisi data binding
        private void dgvPemilik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan baris yang diklik adalah baris data valid (bukan header kolom)
            if (e.RowIndex >= 0 && e.RowIndex < dgvPemilik.Rows.Count)
            {
                // PERBAIKAN: Jika sehabis Insert/Clear ikatannya putus (Count == 0), ikat kembali!
                if (txtNama.DataBindings.Count == 0)
                {
                    AturBindingKomponen();
                }

                // Paksa pemindahan index posisi item aktif sesuai baris yang dipilih user
                pemilikBindingSource.Position = e.RowIndex;
            }
        }

        // Fungsi Agregasi menghitung total baris entitas record tabel
        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM vwPemilikPublic", conn);
                    lblTotal.Text = "Total Pemilik: " + cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 3. INSERT DATA: Memanfaatkan STORED PROCEDURE (Poin 1)
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi input sisi aplikasi (Client-Side Regex Validation)
            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama Pemilik hanya boleh berisi huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtNomor.Text.StartsWith("+628"))
            {
                MessageBox.Show("Gunakan format nomor +628...", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtAlamat.Text, @"^[a-zA-Z0-9\s]+$") || txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("Alamat minimal 5 karakter dan HANYA boleh berisi huruf, angka, atau spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Memanggil objek STORED PROCEDURE 'sp_InsertPemilik'
                    using (SqlCommand cmd = new SqlCommand("sp_InsertPemilik", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Melemparkan data ke parameter Stored Procedure database
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@NoKontak", txtNomor.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil disimpan via Stored Procedure!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TampilkanDataDenganView();
                        HitungTotal();
                        BersihkanLayar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Simpan via SP: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. UPDATE DATA: Memanfaatkan STORED PROCEDURE (Poin 1)
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Pilih data yang ingin diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama hanya boleh huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtAlamat.Text, @"^[a-zA-Z0-9\s]+$") || txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("Alamat minimal 5 karakter dan HANYA boleh berisi huruf, angka, atau spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Memanggil objek STORED PROCEDURE 'sp_UpdatePemilik'
                    using (SqlCommand cmd = new SqlCommand("sp_UpdatePemilik", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@NoKontak", txtNomor.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil diubah via Stored Procedure!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TampilkanDataDenganView();
                        BersihkanLayar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Mengubah via SP: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. DELETE DATA: Memanfaatkan STORED PROCEDURE (Poin 1)
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Pilih data pemilik yang ingin dihapus terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        // Memanggil objek STORED PROCEDURE 'sp_DeletePemilik'
                        using (SqlCommand cmd = new SqlCommand("sp_DeletePemilik", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Data pemilik berhasil dihapus via Stored Procedure!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            TampilkanDataDenganView();
                            HitungTotal();
                            BersihkanLayar();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Gagal Menghapus: Pemilik ini tidak bisa dihapus karena masih memiliki usaha UMKM yang terdaftar.\n\nHapus terlebih dahulu data UMKM milik orang ini.",
                                        "Ketergantungan Hubungan Relasi Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Hapus (Database Error): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // PENGGABUNGAN POIN 3: TOMBOL CEK RENTAN (VULNERABLE SEARCH) UNTUK DEMO SQL INJECTION
        // =========================================================================
        
        }
    }
}