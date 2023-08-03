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

namespace FENERBAHCEFUTBOLOKULU
{
    public partial class kayitolekrani : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
     OleDbDataReader dr;
        DataSet ds;

        public kayitolekrani()
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
        //    dataGridView1.DataSource = ds.Tables["kullanici"];
            con.Close();
        }

        private void kayitsayfasi_cikisbutonu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kayitsayfasi_anasayfabutonu_Click(object sender, EventArgs e)
        {
            girisekrani girisekrani = new girisekrani();
            girisekrani.Show();
            this.Close();
        }

        private void kayitolekrani_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
        public int VarMi(string aranan)
        {
            int sonuc;
            con = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=giris.accdb");
            string sorgu = "Select COUNT(k_ad) from kullanici WHERE k_ad='" + aranan + "'";
            cmd = new OleDbCommand(sorgu, con);
            con.Open();

            sonuc = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return sonuc;

        }

        private void kayitolbutonu_Click(object sender, EventArgs e)
        {
            if (VarMi(kayit_kaditext.Text) != 0)
            {
                MessageBox.Show("Bu kullanıcı adı daha önce kullanılmıştır.");
            }

            else
            {


                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Insert Into kullanici (k_ad,k_sifre) Values ('" + kayit_kaditext.Text + "','" + kayit_sifretext.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
                MessageBox.Show("Kayıt başarıyla gerçekleşmiştir.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                kayit_sifretext.PasswordChar = '\0';
            }

            else
            {
                kayit_sifretext.PasswordChar = '*';
            }
        }
    }
}
