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
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validasi regex sisi aplikasi (Client-Side Validation)
            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Nama Usaha hanya boleh berisi huruf dan spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtAlamat.Text, @"^[a-zA-Z0-9\s]+$") || txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("Alamat minimal 5 karakter dan HANYA boleh berisi huruf, angka, atau spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPemilik.SelectedValue == null)
            {
                MessageBox.Show("Pilih Pemilik UMKM terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Memanggil objek STORED PROCEDURE 'sp_InsertUMKM'
                    using (SqlCommand cmd = new SqlCommand("sp_InsertUMKM", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Melemparkan data ke parameter Stored Procedure database
                        cmd.Parameters.AddWithValue("@NamaUsaha", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@JenisUsaha", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@AlamatUsaha", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@DeskripsiUsaha", txtDesk.Text.Trim());
                        cmd.Parameters.AddWithValue("@IDPemilik", Convert.ToInt32(cmbPemilik.SelectedValue));

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data UMKM berhasil disimpan via Stored Procedure!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TampilkanDataDenganView();
                        BersihkanLayar();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan via SP: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // 4. UPDATE DATA: Memanfaatkan STORED PROCEDURE (Poin 1)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Pilih data UMKM pada tabel yang ingin diubah terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Nama Usaha hanya boleh berisi huruf dan spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Memanggil objek STORED PROCEDURE 'sp_UpdateUMKM'
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUMKM", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IDUMKM", Convert.ToInt32(txtID.Text));
                        cmd.Parameters.AddWithValue("@NamaUsaha", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@JenisUsaha", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@AlamatUsaha", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@DeskripsiUsaha", txtDesk.Text.Trim());
                        cmd.Parameters.AddWithValue("@IDPemilik", Convert.ToInt32(cmbPemilik.SelectedValue));

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data UMKM berhasil diubah via Stored Procedure!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TampilkanDataDenganView();
                        AturBindingKomponen();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update via SP: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                string inputSerangan = txtNama.Text;

                // HAPUS ikatan binding sebelum mengosongkan/mengisi ulang DataTable
                txtID.DataBindings.Clear();
                txtNama.DataBindings.Clear();
                txtAlamat.DataBindings.Clear();
                txtNomor.DataBindings.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM vwPemilikPublic WHERE NamaPemilik = '" + inputSerangan + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                    // Putus binding source ke grid view agar tidak bentrok
                    dgvPemilik.DataSource = null;
                    dtPemilik.Clear();
                    sda.Fill(dtPemilik);

                    if (inputSerangan.Contains("'"))
                    {
                        foreach (DataRow row in dtPemilik.Rows)
                        {
                            row["NamaPemilik"] = "⚠️ ALL IN HACKED ⚠️";
                            row["AlamatPemilik"] = "DATABASE BREACHED!";
                        }

                        dgvPemilik.DataSource = dtPemilik;

                        MessageBox.Show("Skenario Berhasil!\nQuery berhasil ditembus dan dimanipulasi.\nSemua data nama pemilik di memori berhasil di-deface!",
                                        "SQL Injection Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dgvPemilik.DataSource = dtPemilik;
                        // Pasang kembali binding ke textbox jika ini pencarian normal
                        AturBindingKomponen();
                        MessageBox.Show("Pencarian normal selesai.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Eksperimen: " + ex.Message, "SQL Injection Lab", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // PERBAIKAN: Mengosongkan text kotak yang sesungguhnya
        private void BersihkanLayar()
        {
            // Pindahkan posisi binding ke paling akhir/baru agar textbox kosong secara natural
            pemilikBindingSource.Position = -1;

            // Kosongkan teks manual jika posisi -1 belum membersihkannya
            txtID.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            txtNomor.Text = "";

            txtNama.Focus();
        }

        // PERBAIKAN: Mengembalikan Data Binding penuh setelah diacak-acak oleh tombol Test Injection
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Kembalikan semua data ke kondisi normal asal dari SQL Server
            TampilkanDataDenganView();
            AturBindingKomponen();
            HitungTotal();
        }

        // PERBAIKAN: Clear memanggil pengosongan komponen textbox secara nyata
 
        }
}