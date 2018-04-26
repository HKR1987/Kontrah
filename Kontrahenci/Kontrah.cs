using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrahenci
{
    class Kontrah
    {
        int id;
        string nazwa;
        string nazwa_skrocona;

        //adres siedziby
        string adr_ulica;
        int adr_nr_dom;
        int adr_nr_mieskzania;
        string adr_kod_pocztowy;
        string adr_miejscowosc;

        //adres korespondencyjny
        string adrk_ulica;
        int adrk_nr_dom;
        int adrk_nr_mieskzania;
        string adrk_kod_pocztowy;
        string adrk_miejscowosc;

        string telefon;
        string email;
        bool aktywny;

        string nip;
        string pesel;
        string dow_seria;
        string dow_numer;
        string dow_wydal;
        string dow_data_wyd;

        string bank_nazwa;
        string bank_numer;

        int zapl_forma; //np. 1-gotówka; 2-przelew 
        int zapl_termin;
    }
}
