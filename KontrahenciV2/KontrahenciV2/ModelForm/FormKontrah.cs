using KontrahenciV2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KontrahenciV2.ModelForm
{
    public partial class FormKontrah : Form
    {
        private Polaczenie _polaczenie = new Polaczenie();
        private int _id;
        private bool _edycja;

        public FormKontrah()
        {
            InitializeComponent();
            UstawComboBoxy();
            _edycja = false;
        }

        public FormKontrah(int id)
        {
            _id = id;
            InitializeComponent();
            UstawComboBoxy();
            _edycja = true;
            var kontrahent = _polaczenie.PobierzKontrahenta(id);
            UzupelnijKontrolki(kontrahent);
        }

        private void UzupelnijKontrolki(Kontrahent kontrahent)
        {
            textBoxNazwa.Text = kontrahent.Nazwa;
            textBoxNazwaSkr.Text = kontrahent.NazwaSkrocona;
            textBoxNip.Text = kontrahent.Nip;
            textBoxRegon.Text = kontrahent.Regon;
            textBoxTelefon.Text = kontrahent.Telefon;
            textBoxEMail.Text = kontrahent.Email;
            textBoxTermin.Text = kontrahent.TerminZaplaty.ToString();
            comboBoxFormaZaplaty.Text = "" + kontrahent.FormaZaplaty;
            comboBoxStatus.Text = "" + kontrahent.Status;
            if(kontrahent.KontoBankowe !=null)
            {
                textBoxNazwaBanku.Text = kontrahent.KontoBankowe.Nazwa;
                textBoxNrKonta.Text = kontrahent.KontoBankowe.Numer;
            }
            if(kontrahent.AdresSiedziby !=null)
            {
                textBoxUlica1.Text = kontrahent.AdresSiedziby.Ulica;
                textBoxNrD1.Text = kontrahent.AdresSiedziby.NrDomu;
                textBoxNrM1.Text = kontrahent.AdresSiedziby.NrMieszkania;
                textBoxKodP1.Text = kontrahent.AdresSiedziby.KodPocztowy;
                textBoxMiejscowosc1.Text = kontrahent.AdresSiedziby.Miejscowosc;
            }
            if(kontrahent.AdresKorespondencyjny !=null)
            {
                textBoxUlica2.Text = kontrahent.AdresKorespondencyjny.Ulica;
                textBoxNrD2.Text = kontrahent.AdresKorespondencyjny.NrDomu;
                textBoxNrM2.Text = kontrahent.AdresKorespondencyjny.NrMieszkania;
                textBoxKodP2.Text = kontrahent.AdresKorespondencyjny.KodPocztowy;
                textBoxMiejscowosc2.Text = kontrahent.AdresKorespondencyjny.Miejscowosc;
            }
        }

        private void UstawComboBoxy()
        {
            comboBoxStatus.DataSource = Enum.GetValues(typeof(Status));
            comboBoxFormaZaplaty.DataSource = Enum.GetValues(typeof(FormaZaplaty));
        }

        private void CheckBoxAdresKor_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxAdresKor.Enabled = checkBoxAdresKor.Checked ? true : false;
        }

        private void ButtonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonZapisz_Click(object sender, EventArgs e)
        {
            if(_edycja)
            {
                var kontrahent = GenerujKontrahenta();
                _polaczenie.AktualizujKontrahenta(kontrahent, _id);
                this.Close();
            }
            else
            {
                var kontrahent = GenerujKontrahenta();
                DodajKontrahentaDoBazy(kontrahent);
                this.Close();
            }
            
        }

        private void DodajKontrahentaDoBazy(Kontrahent kontrahent)
        {
            var status = _polaczenie.DodajKontrahenta(kontrahent);
            if (status>0)
            {
                MessageBox.Show("Pomyślnie dodano kontrahenta.");
            }
            else
            {
                MessageBox.Show("Błąd przy dodawaniu kontrahenta.");
            }
        }

        private Kontrahent GenerujKontrahenta()
        {
            ParsowanieDanych(out FormaZaplaty forma, out Status status, out int terminZaplaty);
            var kontrahent = new Kontrahent()
            {
                Nazwa = textBoxNazwa.Text,
                NazwaSkrocona = textBoxNazwaSkr.Text,
                Nip = textBoxNip.Text,
                Regon = textBoxRegon.Text,
                Telefon = textBoxTelefon.Text,
                Email = textBoxEMail.Text,
                AdresSiedziby = new Adres(textBoxMiejscowosc1.Text, textBoxUlica1.Text, textBoxNrD1.Text, textBoxNrM1.Text, textBoxKodP1.Text),
                AdresKorespondencyjny = new Adres(textBoxMiejscowosc2.Text, textBoxUlica2.Text, textBoxNrD2.Text, textBoxNrM2.Text, textBoxKodP2.Text),
                KontoBankowe = new KontoBankowe(textBoxNazwaBanku.Text, textBoxNrKonta.Text),
                TerminZaplaty = terminZaplaty,
                FormaZaplaty = forma,
                Status = status
            };
            if (!checkBoxAdresKor.Checked) { kontrahent.AdresKorespondencyjny = kontrahent.AdresSiedziby; }
            return kontrahent;
        }

        private void ParsowanieDanych(out FormaZaplaty forma, out Status status, out int terminZaplaty)
        {
            Enum.TryParse(comboBoxFormaZaplaty.Text, out forma);
            Enum.TryParse(comboBoxStatus.Text, out status);
            terminZaplaty = Int32.Parse(textBoxTermin.Text);
        }
    }
}
