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

namespace Siparis.WinUI.Ekranlar
{
    public partial class KullaniciGirisFrm : Form
    {
        
        public KullaniciGirisFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Parametreler.constr))
            {
                SqlCommand cmd = new SqlCommand("dbo.KullaniciGiris", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TCNo", txtTcno.Text);
                cmd.Parameters.AddWithValue("@Sifre", txtsifre.Text);
                conn.Open();
                SqlDataReader  rdr = cmd.ExecuteReader();
                
                if (rdr.HasRows)
                {
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("TCNo yada sifre yanlistir");
                }
                rdr.Close();
                conn.Close();
            }

        }
    }
}
