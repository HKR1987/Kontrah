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
        private Polaczenie sql = new Polaczenie();
        private Form1 form1;

        public Form2()
        {
            InitializeComponent();
            OdswiezGrid();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            OdswiezGrid();
            form1 = f;
        }

        public void OdswiezGrid()
        {
            try
            {
                dataGridView1.DataSource = sql.pobierz();
            }
            catch (Exception ex)
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
            Form3 f3 = new Form3(this);
            this.Enabled = false;
            f3.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Enabled = true;
        }

        private void b_usun_Click(object sender, EventArgs e)
        {
            int i = Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            sql.usun(i);
            OdswiezGrid();
        }

        private void b_edytuj_Click(object sender, EventArgs e)
        {
            Kontrah k = new Kontrah();
            Form3 f3 = new Form3(this, Konwersje.KonwertujInt(dataGridView1.SelectedCells[0].Value.ToString()), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), Konwersje.KonwertujInt(dataGridView1.SelectedCells[4].Value.ToString()), Konwersje.KonwertujInt(dataGridView1.SelectedCells[5].Value.ToString()), dataGridView1.SelectedCells[6].Value.ToString(), dataGridView1.SelectedCells[7].Value.ToString(), dataGridView1.SelectedCells[8].Value.ToString(), Konwersje.KonwertujInt(dataGridView1.SelectedCells[9].Value.ToString()), Konwersje.KonwertujInt(dataGridView1.SelectedCells[10].Value.ToString()), dataGridView1.SelectedCells[11].Value.ToString(), dataGridView1.SelectedCells[12].Value.ToString(), dataGridView1.SelectedCells[13].Value.ToString(), dataGridView1.SelectedCells[14].Value.ToString(), true, dataGridView1.SelectedCells[16].Value.ToString(), dataGridView1.SelectedCells[17].Value.ToString(), dataGridView1.SelectedCells[18].Value.ToString(), dataGridView1.SelectedCells[19].Value.ToString(), dataGridView1.SelectedCells[20].Value.ToString(), dataGridView1.SelectedCells[21].Value.ToString(), dataGridView1.SelectedCells[22].Value.ToString(), dataGridView1.SelectedCells[23].Value.ToString(), Konwersje.KonwertujInt(dataGridView1.SelectedCells[24].Value.ToString()), Konwersje.KonwertujInt(dataGridView1.SelectedCells[24].Value.ToString()));
            this.Enabled = false;
            f3.Show();
        }
    }
}
