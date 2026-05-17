using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formUMKM : Form
    {
        // Ganti Data Source sesuai dengan nama Server SQL kamu
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        public formUMKM() { InitializeComponent(); }

        private void formUMKM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uMKM_DesaDataSet.Pemilik' table. You can move, or remove it, as needed.
            this.pemilikTableAdapter.Fill(this.uMKM_DesaDataSet.Pemilik);
            // TODO: This line of code loads data into the 'uMKM_DesaDataSet1.UMKM' table. You can move, or remove it, as needed.
            this.uMKMTableAdapter.Fill(this.uMKM_DesaDataSet1.UMKM);
            TampilkanData();
            LoadCombo();
            IsiKategori();
            dgvUMKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtID.ReadOnly = true; // ID tidak boleh diubah manual
        }

        private void TampilkanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT u.IDUMKM, u.NamaUsaha, u.JenisUsaha, u.AlamatUsaha, u.DeskripsiUsaha, p.NamaPemilik, u.IDPemilik " +
                                 "FROM UMKM u JOIN Pemilik p ON u.IDPemilik = p.IDPemilik";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvUMKM.DataSource = dt;
                    if (dgvUMKM.Columns["IDPemilik"] != null) dgvUMKM.Columns["IDPemilik"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Tampil Data: " + ex.Message); }
        }

        private void LoadCombo()
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

        private void IsiKategori()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Kuliner");
            comboBox1.Items.Add("Kerajinan");
            comboBox1.Items.Add("Perdagangan");
            comboBox1.Items.Add("Jasa");
            comboBox1.SelectedIndex = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // 1. CEK NAMA USAHA DULU (Sesuai CHK_NamaUsaha di SQL)
            // Hanya boleh huruf dan spasi
            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Nama Usaha hanya boleh berisi huruf!", "Peringatan");
                return; // Berhenti di sini, jangan lanjut cek alamat
            }

            // 2. CEK ALAMAT (Sesuai CHK_AlamatUsaha di SQL)
            // Minimal 5 karakter
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
                    string q = "INSERT INTO UMKM (NamaUsaha, JenisUsaha, AlamatUsaha, DeskripsiUsaha, IDPemilik) VALUES (@n, @j, @a, @d, @idp)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@n", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@j", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@a", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDesk.Text.Trim());
                    cmd.Parameters.AddWithValue("@idp", cmbPemilik.SelectedValue);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    TampilkanData();
                    BersihkanLayar();
                    MessageBox.Show("Data Berhasil Disimpan!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Pilih data yang akan diubah!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string q = "UPDATE UMKM SET NamaUsaha=@n, JenisUsaha=@j, AlamatUsaha=@a, DeskripsiUsaha=@d, IDPemilik=@idp WHERE IDUMKM=@id";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@n", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@j", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@a", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDesk.Text.Trim());
                    cmd.Parameters.AddWithValue("@idp", cmbPemilik.SelectedValue);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    TampilkanData();
                    MessageBox.Show("Data Berhasil Diperbarui!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (MessageBox.Show("Hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM UMKM WHERE IDUMKM=@id", conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    TampilkanData();
                    BersihkanLayar();
                    MessageBox.Show("Data Berhasil Dihapus!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT u.IDUMKM, u.NamaUsaha, u.JenisUsaha, u.AlamatUsaha, u.DeskripsiUsaha, p.NamaPemilik, u.IDPemilik " +
                                 "FROM UMKM u JOIN Pemilik p ON u.IDPemilik = p.IDPemilik " +
                                 "WHERE u.NamaUsaha LIKE @cari";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    sda.SelectCommand.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvUMKM.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvUMKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUMKM.Rows[e.RowIndex];
                txtID.Text = row.Cells["IDUMKM"].Value.ToString();
                txtNama.Text = row.Cells["NamaUsaha"].Value.ToString();
                comboBox1.Text = row.Cells["JenisUsaha"].Value.ToString();
                txtAlamat.Text = row.Cells["AlamatUsaha"].Value.ToString();
                txtDesk.Text = row.Cells["DeskripsiUsaha"].Value.ToString();
                cmbPemilik.SelectedValue = row.Cells["IDPemilik"].Value;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) { BersihkanLayar(); }

        private void BersihkanLayar()
        {
            txtID.Clear(); txtNama.Clear(); txtAlamat.Clear(); txtDesk.Clear(); txtCari.Clear();
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            TampilkanData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Close();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}