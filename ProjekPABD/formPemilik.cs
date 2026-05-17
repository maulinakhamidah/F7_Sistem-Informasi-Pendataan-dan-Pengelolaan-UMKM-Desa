using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions; // WAJIB: Untuk validasi Regex
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class FormPemilik : Form
    {
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        public FormPemilik() { InitializeComponent(); }

        private void FormPemilik_Load(object sender, EventArgs e) { TampilkanData(); HitungTotal(); }

        private void TampilkanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Pemilik", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvPemilik.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Tampil: " + ex.Message); }
        }

        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pemilik", conn);
                    lblTotal.Text = "Total Pemilik: " + cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // 1. Validasi Nama (Hanya Huruf & Spasi) agar tidak kena CHK_NamaPemilik_Clean
            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama Pemilik hanya boleh berisi huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validasi Nomor Telepon
            if (!txtNomor.Text.StartsWith("+628"))
            {
                MessageBox.Show("Gunakan format nomor +628...");
                return;
            }

            if (!Regex.IsMatch(txtAlamat.Text, @"^[a-zA-Z0-9\s]+$") || txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("Alamat minimal 5 karakter dan HANYA boleh berisi huruf, angka, atau spasi! (Jangan gunakan tanda titik, koma, pagar, dll)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Pemilik (NamaPemilik, AlamatPemilik, NoKontak) VALUES (@nama, @alamat, @hp)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@hp", txtNomor.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil disimpan!");
                    TampilkanData(); HitungTotal(); BersihkanLayar();
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Pilih data yang ingin diubah!"); return; }

            // Validasi Nama juga di tombol Ubah
            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama hanya boleh huruf!");
                return;
            }
            // Validasi Alamat: Minimal harus ada hurufnya, jangan cuma simbol
            if (!Regex.IsMatch(txtAlamat.Text, @"^[a-zA-Z0-9\s]+$") || txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("Alamat minimal 5 karakter dan HANYA boleh berisi huruf, angka, atau spasi! (Jangan gunakan tanda titik, koma, pagar, dll)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Pemilik SET NamaPemilik=@nama, AlamatPemilik=@alamat, NoKontak=@hp WHERE IDPemilik=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@hp", txtNomor.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diubah!");
                    TampilkanData(); BersihkanLayar();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Pilih data pemilik yang ingin dihapus terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM Pemilik WHERE IDPemilik=@id", conn);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data pemilik berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TampilkanData(); HitungTotal(); BersihkanLayar();
                    }
                }
                catch (SqlException ex)
                {
                    // Error nomor 547 adalah conflict foreign key / reference constraint di SQL Server
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Gagal Menghapus: Pemilik ini tidak bisa dihapus karena masih memiliki usaha UMKM yang terdaftar.\n\nHapus terlebih dahulu data UMKM milik orang ini sebelum menghapus data pemilik.",
                                        "Ketergantungan Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void dgvPemilik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPemilik.Rows[e.RowIndex];
                txtID.Text = row.Cells["IDPemilik"].Value.ToString();
                txtNama.Text = row.Cells["NamaPemilik"].Value.ToString();
                txtAlamat.Text = row.Cells["AlamatPemilik"].Value.ToString();
                txtNomor.Text = row.Cells["NoKontak"].Value.ToString();
            }
        }

        private void BersihkanLayar()
        {
            txtID.Clear(); txtNama.Clear(); txtAlamat.Clear(); txtNomor.Clear();
            txtNama.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e) { BersihkanLayar(); }

        private void button1_Click(object sender, EventArgs e)
        {
            // Menutup form ini dan kembali ke Menu Utama (Form2)
            Form2 menu = new Form2();
            menu.Show();
            this.Hide();
        }
    }
}