using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formLaporan : Form
    {
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        public formLaporan() { InitializeComponent(); }

        private void formLaporan_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string q = @"SELECT p.NamaPemilik, u.NamaUsaha, pr.NamaProduk, pr.Harga 
                                 FROM Pemilik p 
                                 JOIN UMKM u ON p.IDPemilik = u.IDPemilik 
                                 JOIN Produk pr ON u.IDUMKM = pr.IDUMKM";
                    SqlDataAdapter sda = new SqlDataAdapter(q, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvLaporan.DataSource = dt;
                    dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Laporan: " + ex.Message);
            }
        }

       
            
        
    }
}