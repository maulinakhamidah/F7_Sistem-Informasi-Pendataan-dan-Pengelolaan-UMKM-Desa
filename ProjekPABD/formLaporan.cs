using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formLaporan : Form
    {
        // 1. Tambahkan deklarasi koneksi di sini agar variabel 'conn' dikenali
        SqlConnection conn = new SqlConnection("Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public formLaporan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 menuUtama = new Form2();
            menuUtama.Show();
            this.Close();
        }

        
    }
}