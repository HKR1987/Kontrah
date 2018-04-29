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
        private Label[] etyk;
        private TextBox[] textboxy;
        private Polaczenie sql = new Polaczenie();
        private Form2 form2;
        private int id_kontrah=0;

        public Form3()
        {
            InitializeComponent();
            RysujKontrolki();
        }

        public Form3(Form2 f)
        {
            InitializeComponent();
            RysujKontrolki();
            form2 = f;
        }

        public Form3(Form2 f, int id, string nazwa, string nazwa_skrocona, string adr_ulica, int adr_nr_dom, int adr_nr_mieszkania, string adr_kod_pocztowy, string adr_miejscowosc, string adrk_ulica, int adrk_nr_dom, int adrk_nr_mieszkania, string adrk_kod_pocztowy, string adrk_miejscowosc, string telefon, string email, bool aktywny, string nip, string pesel, string dow_seria, string dow_numer, string dow_wydal, string dow_data_wyd, string bank_nazwa, string bank_numer, int zapl_forma, int zapl_termin)
        {
            InitializeComponent();
            RysujKontrolki();
            form2 = f;
            id_kontrah = id;
            b_zapisz.Text = "Zapisz";
            this.Text = "Edycja kontrahenta";
            textboxy[0].Text = nazwa;
            textboxy[1].Text = nazwa_skrocona;
            textboxy[2].Text = adr_ulica;
            textboxy[3].Text = Convert.ToString(adr_nr_dom);
            textboxy[4].Text = Convert.ToString(adr_nr_mieszkania);
            textboxy[5].Text = adr_kod_pocztowy;
            textboxy[6].Text = adr_miejscowosc;
            textboxy[7].Text = adrk_ulica;
            textboxy[8].Text = Convert.ToString(adrk_nr_dom);
            textboxy[9].Text = Convert.ToString(adrk_nr_mieszkania);
            textboxy[10].Text = adrk_kod_pocztowy;
            textboxy[11].Text = adrk_miejscowosc;
            textboxy[12].Text = telefon;
            textboxy[13].Text = email;
            textboxy[14].Text = Convert.ToString(aktywny);
            textboxy[15].Text = nip;
            textboxy[16].Text = pesel;
            textboxy[17].Text = dow_seria;
            textboxy[18].Text = dow_numer;
            textboxy[19].Text = dow_wydal;
            textboxy[20].Text = dow_data_wyd;
            textboxy[21].Text = bank_nazwa;
            textboxy[22].Text = bank_numer;
            textboxy[23].Text = Convert.ToString(zapl_forma);
            textboxy[24].Text = Convert.ToString(zapl_termin);
        }

        /// <summary>
        /// Tworzy kontrolki na Form
        /// </summary>
        private void RysujKontrolki()
        {
            etyk = new Label[25];
            textboxy = new TextBox[25];
            string[] nazwy = { "b_nazwa", "b_nazwa_skrocona", "b_adr_ulica", "b_adr_nr_dom", "b_adr_nr_mieszkania", "b_adr_kod_pocztowy", "b_adr_miejscowosc", "b_adrk_ulica", "b_adrk_nr_dom", "b_adrk_nr_mieszkania", "b_adrk_kod_pocztowy", "b_adrk_miejscowosc", "b_telefon", "b_email", "b_aktywny", "b_nip", "b_pesel", "b_dow_seria", "b_dow_numer", "b_dow_wydal", "b_dow_data_wyd", "b_bank_nazwa", "b_bank_numer", "b_zapl_forma", "b_zapl_termin" };
            string[] nazwy_etyk = { "Nazwa", "Nazwa skrócona", "Ulica", "Nr domu", "Nr mieszkania", "Kod pocztowy", "Miejscowość", "Ulica", "Nr domu", "Nr mieszkania", "Kod pocztowy", "Miejscowosc", "Telefon", "e-mail", "Czy aktywny", "Nip", "Pesel", "Seria D.O.", "Nr D.O.", "D.O. wydany przez", "Daty wyd. D.O.", "Nazwa banku", "Numer konta", "Forma zapłaty", "Termin zapłaty" };
            int j = 12;
            int k = 112;
            int l = 0;
            
            for (int i = 0; i < textboxy.Length; i++)
            {
                //MessageBox.Show(nazwy[i]);
                if (i == 12)
                {
                    j += 224;
                    k += 224;
                    l = 0;
                }
                var lbl = new Label();
                var txt = new TextBox();
                lbl.Location = new Point(j, 10 + (l * 33));
                txt.Location = new Point(k, 10 + (l * 33));
                lbl.Text = nazwy_etyk[i];
                //txt.Text = Convert.ToString(txt.Height) + "::" + Convert.ToString(txt.Width)+"dd"+ Convert.ToString(txt.Location.Y);
                txt.Name = nazwy[i];
                if (i == 14)
                {
                    txt.Text = "true";
                }
                lbl.Visible = true;
                txt.Visible = true;
                etyk[i] = lbl;
                textboxy[i] = txt;
                this.Controls.Add(etyk[i]);
                this.Controls.Add(textboxy[i]);
                l++;
            }
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            Kontrah k = new Kontrah(textboxy[0].Text, textboxy[1].Text, textboxy[2].Text, Konwersje.KonwertujInt(textboxy[3].Text), Konwersje.KonwertujInt(textboxy[4].Text), textboxy[5].Text, textboxy[6].Text, textboxy[7].Text, Konwersje.KonwertujInt(textboxy[8].Text), Konwersje.KonwertujInt(textboxy[9].Text), textboxy[10].Text, textboxy[11].Text, textboxy[12].Text, textboxy[13].Text, Convert.ToBoolean(textboxy[14].Text), textboxy[15].Text, textboxy[16].Text, textboxy[17].Text, textboxy[18].Text, textboxy[19].Text, textboxy[20].Text, textboxy[21].Text, textboxy[22].Text, Konwersje.KonwertujInt(textboxy[23].Text), Konwersje.KonwertujInt(textboxy[24].Text));
            if(id_kontrah==0)
            {
                sql.dodaj(k);
            }
            else
            {
                sql.edytuj(id_kontrah, k);
            }
            this.Close();
            form2.OdswiezGrid();
        }
        
        private void b_anuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Enabled = true;
        }
    }
}
