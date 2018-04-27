using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrahenci
{
    public partial class Form2 : Form
    {

        Polaczenie sql = new Polaczenie();
        public Form2()
        {
            InitializeComponent();
            try
            {
                dataGridView1.DataSource = sql.pobierz();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void b_spr_Click(object sender, EventArgs e)
        {
            //sql = new Polaczenie();
            sql.polacz();
        }

        private void b_tworz_Click(object sender, EventArgs e)
        {
            //sql = new Polaczenie();
            sql.tworzTabele();
        }

        private void b_dodaj_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void b_wybierz_Click(object sender, EventArgs e)
        {

        }
    }
}
