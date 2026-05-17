using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class Form2 : Form
    {
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        public Form2() { InitializeComponent(); }

        private void Form2_Load(object sender, EventArgs e) { CheckConnection(); }

        private void CheckConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    lblKoneksi.Text = "Status: Terhubung";
                    lblKoneksi.ForeColor = Color.Green;
                }
                catch
                {
                    lblKoneksi.Text = "Status: Terputus";
                    lblKoneksi.ForeColor = Color.Red;
                }
            }
        }

        private void btnKeUMKM_Click(object sender, EventArgs e) { new formUMKM().Show(); this.Hide(); }
        private void btnPemilik_Click(object sender, EventArgs e) { new FormPemilik().Show(); this.Hide(); }
        private void btnKeProduk_Click(object sender, EventArgs e) { new formProduk().Show(); this.Hide(); }
        
    }
}