using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FENERBAHCEFUTBOLOKULU
{
    public partial class veriekrani : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        public veriekrani()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=veritabani.accdb");
            da = new OleDbDataAdapter("SElect *from Kisiler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kisiler");
            verigösterme.DataSource = ds.Tables["Kisiler"];
            con.Close();

        }

        private void veriekrani_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void verigösterme_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            idtext.Text = verigösterme.CurrentRow.Cells[0].Value.ToString();
            adisoyadi.Text = verigösterme.CurrentRow.Cells[1].Value.ToString();
            yasi.Text = verigösterme.CurrentRow.Cells[2].Value.ToString();
            telefon.Text = verigösterme.CurrentRow.Cells[3].Value.ToString();
            borcu.Text = verigösterme.CurrentRow.Cells[4].Value.ToString();
            mevki.Text = verigösterme.CurrentRow.Cells[5].Value.ToString();
            secilme.Text = verigösterme.CurrentRow.Cells[6].Value.ToString();
            resim.Text = verigösterme.CurrentRow.Cells[7].Value.ToString();
            resimgösterme.ImageLocation = resim.Text;




        }

        private void ekle_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Kisiler (Adi_Soyadi,Yasi,Telefon_Numarasi,Borcu,Mevki,Secilme_Durumu,Resim) values ('" + adisoyadi.Text + "','" + yasi.Text + "','" + telefon.Text + "','" + borcu.Text + "','" + mevki.Text + "','" + secilme.Text + "','" + resim.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            

        }

        private void resimyükle_Click(object sender, EventArgs e)
        {

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            resim.Text = dosyayolu;
            resimgösterme.ImageLocation = dosyayolu;

        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update Kisiler set Adi_Soyadi='" + adisoyadi.Text + "',Yasi='" + yasi.Text + "',Telefon_Numarasi='" + telefon.Text + "',Borcu='" + borcu.Text + "',Mevki='" + mevki.Text + "',Secilme_Durumu='" + secilme.Text + "',Resim='" + resim.Text + "' where ID=" + idtext.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from Kisiler where ID=" + idtext.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void arama_TextChanged(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=veritabani.accdb");
            da = new OleDbDataAdapter("SElect *from Kisiler where Adi_Soyadi like '" + arama.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kisiler");
            verigösterme.DataSource = ds.Tables["Kisiler"];
            con.Close();
        }

        private void cikisbutonu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
             veriiliski veriiliski = new veriiliski();
            veriiliski.Show();
            this.Hide();
        }
    }
}
