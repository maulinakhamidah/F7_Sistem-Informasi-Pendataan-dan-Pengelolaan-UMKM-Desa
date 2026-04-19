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

    }  
}