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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            TextBox[] textboxy = new TextBox[25];
            string[] nazwy ={ "b_nazwa", "b_nazwa_skrocona", "b_adr_ulica", "b_adr_nr_dom", "b_adr_nr_mieskzania", "b_adr_kod_pocztowy", "b_adr_miejscowosc", "b_adrk_ulica", "b_adrk_nr_dom", "b_adrk_nr_mieskzania", "b_adrk_kod_pocztowy", "b_adrk_miejscowosc", "b_telefon", "b_email", "b_aktywny", "b_nip", "b_pesel", "b_dow_seria", "b_dow_numer", "b_dow_wydal", "b_dow_data_wyd", "b_bank_nazwa", "b_bank_numer", "b_zapl_forma", "b_zapl_termin"};
            for (int i = 0; i < textboxy.Length; i++)
            {
                var txt = new TextBox();
                textboxy[i] = txt;
                txt.Name = nazwy[i];
                txt.Text = nazwy[i];
                txt.Location = new Point(5, 32 + (i * 28));
                txt.Visible = true;
            }
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            TextBox[] textboxy = new TextBox[25];
            string[] nazwy = { "b_nazwa", "b_nazwa_skrocona", "b_adr_ulica", "b_adr_nr_dom", "b_adr_nr_mieskzania", "b_adr_kod_pocztowy", "b_adr_miejscowosc", "b_adrk_ulica", "b_adrk_nr_dom", "b_adrk_nr_mieskzania", "b_adrk_kod_pocztowy", "b_adrk_miejscowosc", "b_telefon", "b_email", "b_aktywny", "b_nip", "b_pesel", "b_dow_seria", "b_dow_numer", "b_dow_wydal", "b_dow_data_wyd", "b_bank_nazwa", "b_bank_numer", "b_zapl_forma", "b_zapl_termin" };
            for (int i = 0; i < textboxy.Length; i++)
            {
                var txt = new TextBox();
                textboxy[i] = txt;
                txt.Name = nazwy[i];
                txt.Text = nazwy[i];
                txt.Location = new Point(5, 32 + (i * 28));
                txt.Visible = true;
            }

        }
    }
}
