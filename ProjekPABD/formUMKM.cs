using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formUMKM : Form
    {
        // Connection String sesuai server kamu
        SqlConnection conn = new SqlConnection("Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public formUMKM()
        {
            InitializeComponent();
        }

        private void formUMKM_Load(object sender, EventArgs e)
        {
            TampilkanData();
            LoadComboPemilik();
        }

        // Tampilkan Data dengan JOIN agar muncul Nama Pemilik (bukan cuma ID)
        private void TampilkanData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = @"SELECT u.IDUMKM, u.NamaUsaha, u.JenisUsaha, u.AlamatUsaha, u.DeskripsiUsaha, p.NamaPemilik 
                                 FROM UMKM u 
                                 JOIN Pemilik p ON u.IDPemilik = p.IDPemilik";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvUMKM.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Tampil: " + ex.Message); }
        }

        // Mengambil daftar pemilik untuk ComboBox Nama Pemilik
        private void LoadComboPemilik()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDPemilik, NamaPemilik FROM Pemilik", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cmbPemilik.DataSource = dt;
                cmbPemilik.DisplayMember = "NamaPemilik"; // Yang tampil di layar
                cmbPemilik.ValueMember = "IDPemilik";     // Nilai ID yang disimpan ke DB
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Load Pemilik: " + ex.Message); conn.Close(); }
        }

        // INSERT (Tombol Simpan/Insert)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                // Kolom database disesuaikan: AlamatUsaha, JenisUsaha, DeskripsiUsaha
                SqlCommand cmd = new SqlCommand(@"INSERT INTO UMKM (NamaUsaha, JenisUsaha, AlamatUsaha, DeskripsiUsaha, IDPemilik) 
                                                VALUES (@nama, @jenis, @alamat, @desc, @idp)", conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@jenis", cmbJenis.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesk.Text);
                cmd.Parameters.AddWithValue("@idp", cmbPemilik.SelectedValue);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data UMKM Berhasil Disimpan!");
                TampilkanData();
                BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); conn.Close(); }
        }

        // UPDATE (Tombol Ubah)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE UMKM SET NamaUsaha=@nama, JenisUsaha=@jenis, 
                                                AlamatUsaha=@alamat, DeskripsiUsaha=@desc, IDPemilik=@idp 
                                                WHERE IDUMKM=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@jenis", cmbJenis.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesk.Text);
                cmd.Parameters.AddWithValue("@idp", cmbPemilik.SelectedValue);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data UMKM Berhasil Diperbarui!");
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); conn.Close(); }
        }

        // DELETE (Tombol Hapus)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM UMKM WHERE IDUMKM=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data UMKM Berhasil Dihapus!");
                TampilkanData();
                BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); conn.Close(); }
        }

        // SEARCH (Cari Nama Usaha)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = @"SELECT u.IDUMKM, u.NamaUsaha, u.JenisUsaha, u.AlamatUsaha, u.DeskripsiUsaha, p.NamaPemilik 
                                 FROM UMKM u 
                                 JOIN Pemilik p ON u.IDPemilik = p.IDPemilik 
                                 WHERE u.NamaUsaha LIKE @cari";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvUMKM.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); conn.Close(); }
        }

        private void dgvUMKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUMKM.Rows[e.RowIndex];
                txtID.Text = row.Cells["IDUMKM"].Value.ToString();
                txtNama.Text = row.Cells["NamaUsaha"].Value.ToString();
                cmbJenis.Text = row.Cells["JenisUsaha"].Value.ToString();
                txtAlamat.Text = row.Cells["AlamatUsaha"].Value.ToString();
                txtDesk.Text = row.Cells["DeskripsiUsaha"].Value.ToString();
                cmbPemilik.Text = row.Cells["NamaPemilik"].Value.ToString();
            }
        }

        private void BersihkanLayar()
        {
            txtID.Clear(); txtNama.Clear(); txtAlamat.Clear(); txtDesk.Clear(); txtCari.Clear();
            cmbJenis.SelectedIndex = -1;
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

        private void dgvUMKM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil baris yang diklik
                DataGridViewRow row = dgvUMKM.Rows[e.RowIndex];

                // Pindahkan data dari kolom tabel ke TextBox di atas
                // Sesuaikan nama kolom "IDUMKM", "NamaUsaha", dll dengan nama di database kamu
                txtID.Text = row.Cells["IDUMKM"].Value.ToString();
                txtNama.Text = row.Cells["NamaUsaha"].Value.ToString();
                cmbJenis.Text = row.Cells["JenisUsaha"].Value.ToString();
                txtAlamat.Text = row.Cells["AlamatUsaha"].Value.ToString();
                txtDesk.Text = row.Cells["DeskripsiUsaha"].Value.ToString();
            }
        }
    }
}