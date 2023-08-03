using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FENERBAHCEFUTBOLOKULU
{
    public partial class veriiliski : Form
    {
        public veriiliski()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        private void veriiliski_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=iller.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from iller ORDER BY id ASC ", con);
            da.Fill(dt);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "sehir";
            comboBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from ilceler where sehir = " + comboBox1.SelectedValue, con);
                da.Fill(dt);
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "ilce";
                comboBox2.DataSource = dt;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            veriekrani veriekrani = new veriekrani();
            veriekrani.Show();
            this.Close();
        }
    }
}
