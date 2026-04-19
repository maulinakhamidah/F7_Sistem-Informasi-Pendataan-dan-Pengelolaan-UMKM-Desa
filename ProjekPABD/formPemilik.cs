using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class FormPemilik : Form
    {
        // Connection String sesuai server kamu
        SqlConnection conn = new SqlConnection("Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public FormPemilik()
        {
            InitializeComponent();
        }

        private void FormPemilik_Load(object sender, EventArgs e)
        {
            TampilkanData();
            HitungTotalPemilik();
        }

        // Tampilkan Data sesuai kolom di SQL (AlamatPemilik, NoKontak)
        private void TampilkanData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Pemilik", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvPemilik.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Tampil: " + ex.Message); }
        }

        private void HitungTotalPemilik()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pemilik", conn);
                lblTotal.Text = "Total Pemilik: " + cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // INSERT: ID tidak dimasukkan karena IDENTITY di SQL
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Pemilik (NamaPemilik, AlamatPemilik, NoKontak) VALUES (@nama, @alamat, @hp)", conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@hp", txtNomor.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Berhasil Disimpan!");
                TampilkanData(); HitungTotalPemilik(); BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); conn.Close(); }
        }

        // UPDATE: Sesuaikan nama kolom SQL
        private void btnUbah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Pemilik SET NamaPemilik=@nama, AlamatPemilik=@alamat, NoKontak=@hp WHERE IDPemilik=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.Parameters.AddWithValue("@hp", txtNomor.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Berhasil Diperbarui!");
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); conn.Close(); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Pemilik WHERE IDPemilik=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Berhasil Dihapus!");
                TampilkanData(); HitungTotalPemilik(); BersihkanLayar();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); conn.Close(); }
        }

        private void dgvPemilik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPemilik.Rows[e.RowIndex];
                txtID.Text = row.Cells["IDPemilik"].Value.ToString();
                txtNama.Text = row.Cells["NamaPemilik"].Value.ToString();
                txtAlamat.Text = row.Cells["AlamatPemilik"].Value.ToString();
                txtNomor.Text = row.Cells["NoKontak"].Value.ToString();
            }
        }

        private void BersihkanLayar()
        {
            txtID.Clear(); txtNama.Clear(); txtAlamat.Clear(); txtNomor.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e) { BersihkanLayar(); }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            new Form2().Show(); this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Menampilkan kembali Form Menu Utama (Form2)
            Form2 menuUtama = new Form2();
            menuUtama.Show();

            // Menutup form yang sekarang sedang dibuka
            this.Close();
        }
    }
}