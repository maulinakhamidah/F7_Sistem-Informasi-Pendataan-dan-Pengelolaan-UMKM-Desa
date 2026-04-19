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
        // Connection String sesuai database kamu
        SqlConnection conn = new SqlConnection("Data Source= LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            StyleForm(); // Panggil fungsi desain saat form dibuat
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set TextBox Password agar menampilkan bintang/bulatan
            txtPass.UseSystemPasswordChar = true;
        }

        // =========================== FUNGSI DESAIN (STYLE) ===========================
        private void StyleForm()
        {
            // 1. Membuat Form Rounded (Sudut Tumpul)
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            this.Region = new Region(path);

            // 2. Desain Tombol (Rounded, No Border)
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(0, 191, 166); // Hijau Toska Logo
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;

            // 3. Efek Hover Tombol
            btnLogin.MouseEnter += (s, e) => { btnLogin.BackColor = Color.FromArgb(0, 161, 140); };
            btnLogin.MouseLeave += (s, e) => { btnLogin.BackColor = Color.FromArgb(0, 191, 166); };
        }

        // Membuat Efek Bayangan (Shadow) pada Form
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // Custom Paint untuk Kotak Input (Garis Bawah)
        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            // Gambar garis bawah untuk Username
            e.Graphics.DrawLine(new Pen(Color.LightGray, 2), txtUsername.Left, txtUsername.Bottom + 5, txtUsername.Right, txtUsername.Bottom + 5);
            // Gambar garis bawah untuk Password
            e.Graphics.DrawLine(new Pen(Color.LightGray, 2), txtPass.Left, txtPass.Bottom + 5, txtPass.Right, txtPass.Bottom + 5);
        }

        // =========================== LOGIKA LOGIN (DATABASE) ===========================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Username dan Password wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                // Menggunakan query berparameter untuk keamanan
                string query = "SELECT COUNT(*) FROM Admin WHERE Username=@user AND PasswordAdmin=@pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text); // Lebih baik di-hash di produksi

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                if (count == 1)
                {
                    // Login Sukses
                    this.Hide();
                    Form2 dasbor = new Form2();
                    dasbor.Show();
                }
                else
                {
                    // Login Gagal
                    MessageBox.Show("Username atau Password salah!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Terhubung ke Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        
    }
}