using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class Form2 : Form
    {
        // Gunakan connection string yang sama dengan Form 1
        SqlConnection conn = new SqlConnection(
            "Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Panggil pengecekan koneksi saat dashboard terbuka
            CheckConnection();
        }

        // FUNGSI CEK KONEKSI (POIN UJIAN BAGIAN B)
        private void CheckConnection()
        {
            try
            {
                conn.Open();
                lblKoneksi.Text = "Status Koneksi: Terhubung";
                lblKoneksi.ForeColor = Color.Green;
                conn.Close();
            }
            catch (Exception)
            {
                lblKoneksi.Text = "Status Koneksi: Terputus";
                lblKoneksi.ForeColor = Color.Red;
            }
        }

        // NAVIGASI KE FORM UMKM
        private void btnKeUMKM_Click(object sender, EventArgs e)
        {
            formUMKM fUMKM = new formUMKM();
            fUMKM.Show();
            this.Hide();
        }

        // NAVIGASI KE FORM PEMILIK
        private void btnPemilik_Click(object sender, EventArgs e)
        {
            FormPemilik fPemilik = new FormPemilik();
            fPemilik.Show();
            this.Hide();
        }


        // NAVIGASI KE FORM PRODUK
        private void btnKeProduk_Click(object sender, EventArgs e)
        {
            formProduk fProduk = new formProduk();
            fProduk.Show();
            this.Hide();
        }

        // LOGOUT
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Menampilkan pesan konfirmasi sebelum keluar
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 1. Panggil Form Login (Form1)
                Form1 loginForm = new Form1();
                loginForm.Show();

                // 2. Tutup Form Menu Utama (Form2)
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formLaporan laporan = new formLaporan();
            laporan.Show();
            this.Hide();
        }
    }
}
