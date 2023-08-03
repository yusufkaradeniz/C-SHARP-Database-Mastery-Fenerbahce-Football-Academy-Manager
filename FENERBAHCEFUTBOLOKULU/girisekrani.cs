using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.VisualStyles;

namespace FENERBAHCEFUTBOLOKULU
{
    public partial class girisekrani : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        OleDbDataReader dr;
        DataSet ds;

        public girisekrani()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=giris.accdb");
            da = new OleDbDataAdapter("SElect *from kullanici", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kullanici");
          //  dataGridView1.DataSource = ds.Tables["kullanici"];
            con.Close();
        }

        private void kayitolekranibutonu_Click(object sender, EventArgs e)
        {
            kayitolekrani kayitolekrani = new kayitolekrani();
            kayitolekrani.Show();
            this.Hide();
        }

        private void girissayfasi_cikisbutonu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void girisekrani_Load(object sender, EventArgs e)
        {
            griddoldur();
            veriekraniniac.Visible= false;
            güncelle.Visible= false;
        }

        private void girisbutonu_Click(object sender, EventArgs e)
        {

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=giris.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanici where k_ad='" + girisk_aditext.Text + "' AND k_sifre='" + giris_sifretext.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sari.Visible= false;
               
                lacivert.Visible= false;
                güncelle.Visible = true;
                veriekraniniac.Visible = true;
                MessageBox.Show("Hoşgeldiniz " + girisk_aditext.Text);
              
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                giris_sifretext.PasswordChar = '\0';
            }

            else
            {
                giris_sifretext.PasswordChar = '*';
            }
        }

      
        private void güncelle_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update kullanici set k_ad='" + girisk_aditext.Text + "',k_sifre='" + giris_sifretext.Text + "'  ";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Kayıt başarıyla güncellenmiştir");
        }

     

        private void veriekraniniac_Click(object sender, EventArgs e)
        {
            veriekrani veriekrani = new veriekrani();
            veriekrani.Show();
            this.Hide();
        }
    }
}
