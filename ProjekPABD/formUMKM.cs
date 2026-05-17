using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjekPABD
{
    public partial class formUMKM : Form
    {
        // Menyinkronkan DataSource sesuai server lokal terupdate milikmu
        string connectionString = "Data Source=LAPTOP-66MU6CLK\\MAULINAA;Initial Catalog=UMKM_Desa;Integrated Security=True";

        // Deklarasi Komponen Sinkronisasi Data Binding (Poin 4 & 5)
        private BindingSource bSource = new BindingSource();
        private DataTable dtUMKM = new DataTable();

        public formUMKM()
        {
            InitializeComponent();
        }

        private void formUMKM_Load(object sender, EventArgs e)
        {
            // Load data dasar untuk ComboBox Pemilik terlebih dahulu
            LoadComboPemilik();
            IsiKategoriUsaha();

            // Jalankan sinkronisasi komponen arsitektur View dan Data Binding
            TampilkanDataDenganView();
            AturBindingKomponen();

            dgvUMKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtID.ReadOnly = true; // ID menggunakan IDENTITY, tidak boleh diubah manual
            dgvUMKM.ReadOnly = true;
            dgvUMKM.AllowUserToAddRows = false;
            dgvUMKM.AllowUserToDeleteRows = false;
        }

        // 1. SELECT DATA: Mengubah query dasar menjadi VIEW (Poin 2)
        
        }
    }
}