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

        
    }
}
