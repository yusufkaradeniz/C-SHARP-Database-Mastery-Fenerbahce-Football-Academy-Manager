using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FENERBAHCEFUTBOLOKULU
{
    public partial class Loadingekrani : Form
    {
        public Loadingekrani()
        {
            InitializeComponent();
        }
      

        private void Loadingekrani_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loadingbar.Value != loadingbar.Maximum)
                loadingbar.Value++;
            else
            {
                timer1.Stop();
                this.Hide();
                girisekrani girisekrani = new girisekrani();
                girisekrani.Show();
            }









        }
    }
}
