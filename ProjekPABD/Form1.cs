using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            StyleForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void StyleForm()
        {
            GraphicsPath path = new GraphicsPath();
            int r = 20;
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(this.Width - r, 0, r, r, 270, 90);
            path.AddArc(this.Width - r, this.Height - r, r, r, 0, 90);
            path.AddArc(0, this.Height - r, r, r, 90, 90);
            this.Region = new Region(path);

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(0, 191, 166);
            btnLogin.ForeColor = Color.White;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPass.Text)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Admin WHERE Username=@user AND PasswordAdmin=@pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                    conn.Open();
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        this.Hide();
                        new Form2().Show();
                    }
                    else
                    {
                        MessageBox.Show("Username/Password Salah!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e) 
        {
             // Menampilkan pesan konfirmasi logout secara eksplisit
            DialogResult dr = MessageBox.Show("Apakah anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Buka kembali halaman Form Login (Form1)
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide(); // Sembunyikan form laporan ini, biarkan Form1 yang berjalan
            }
            // Jika user memilih 'No', sistem tidak akan melakukan apa-apa dan form laporan tetap terbuka
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbLogin_Click(object sender, EventArgs e)
        {

        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }
    }
}