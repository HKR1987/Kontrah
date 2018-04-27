using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrahenci
{
    class Kontrah
    {
        int Id { get; set; }
        public string Nazwa { get; set; }
        public string Nazwa_skrocona { get; set; }

        //adres siedziby
        public string Adr_ulica { get; set; }
        public int Adr_nr_dom { get; set; }
        public int Adr_nr_mieszkania { get; set; }
        public string Adr_kod_pocztowy { get; set; }
        public string Adr_miejscowosc { get; set; }

        //adres korespondencyjny
        public string Adrk_ulica { get; set; }
        public int Adrk_nr_dom { get; set; }
        public int Adrk_nr_mieszkania { get; set; }
        public string Adrk_kod_pocztowy { get; set; }
        public string Adrk_miejscowosc { get; set; }

        public string Telefon { get; set; }
        public string Email { get; set; }
        public bool Aktywny { get; set; }

        public string Nip { get; set; }
        public string Pesel { get; set; }
        public string Dow_seria { get; set; }
        public string Dow_numer { get; set; }
        public string Dow_wydal { get; set; }
        public string Dow_data_wyd { get; set; }

        public string Bank_nazwa { get; set; }
        public string Bank_numer { get; set; }

        public int Zapl_forma { get; set; } //np. 1-gotówka; 2-przelew 
        public int Zapl_termin { get; set; }

        public Kontrah()
        {

        }

        public Kontrah(int id, string nazwa, string nazwa_skrocona, string adr_ulica, int adr_nr_dom, int adr_nr_mieszkania, string adr_kod_pocztowy, string adr_miejscowosc, string adrk_ulica, int adrk_nr_dom, int adrk_nr_mieszkania, string adrk_kod_pocztowy, string adrk_miejscowosc, string telefon, string email, bool aktywny, string nip, string pesel, string dow_seria, string dow_numer, string dow_wydal, string dow_data_wyd, string bank_nazwa, string bank_numer, int zapl_forma, int zapl_termin)
        {
            Id = id;
            Nazwa = nazwa;
            Nazwa_skrocona = nazwa_skrocona;
            Adr_ulica = adr_ulica;
            Adr_nr_dom = adr_nr_dom;
            Adr_nr_mieszkania = adr_nr_mieszkania;
            Adr_kod_pocztowy = adr_kod_pocztowy;
            Adr_miejscowosc = adr_miejscowosc;
            Adrk_ulica = adrk_ulica;
            Adrk_nr_dom = adrk_nr_dom;
            Adrk_nr_mieszkania = adrk_nr_mieszkania;
            Adrk_kod_pocztowy = adrk_kod_pocztowy;
            Adrk_miejscowosc = adrk_miejscowosc;
            Telefon = telefon;
            Email = email;
            Aktywny = aktywny;
            Nip = nip;
            Pesel = pesel;
            Dow_seria = dow_seria;
            Dow_numer = dow_numer;
            Dow_wydal = dow_wydal;
            Dow_data_wyd = dow_data_wyd;
            Bank_nazwa = bank_nazwa;
            Bank_numer = bank_numer;
            Zapl_forma = zapl_forma;
            Zapl_termin = zapl_termin;
        }
    }
}
