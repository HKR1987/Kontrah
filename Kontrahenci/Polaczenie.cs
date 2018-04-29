using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrahenci
{
    class Polaczenie
    {
        static string serwer = "HKRPC\\SQLEXPRESS";
        static string baza = "test";
        static string uzytkownik = "sa";
        static string haslo = "sa@";
        string connetionString = "Data Source="+serwer+";Initial Catalog="+baza+";User ID="+uzytkownik+";Password="+haslo;
        SqlConnection sql;
        SqlCommand polecenie;
        string zap_pobieranie = @"SELECT * FROM kontrah";
        string zap_usuwanie = "DELETE FROM kontrah where id=";
        string zap_tworzenie = @"
                CREATE TABLE [kontrah](
                Id [int] IDENTITY(1,1) NOT NULL,
                Nazwa [nchar](50) NULL,
                Nazwa_skrocona [nchar](50) NULL,
                Adr_ulica [nchar](50) NULL,
                Adr_nr_dom [int] NULL,
                Adr_nr_mieszkania [int] NULL,
                Adr_kod_pocztowy [nchar](50) NULL,
                Adr_miejscowosc [nchar](50) NULL,
                Adrk_ulica [nchar](50) NULL,
                Adrk_nr_dom [int] NULL,
                Adrk_nr_mieszkania [int] NULL,
                Adrk_kod_pocztowy [nchar](50) NULL,
                Adrk_miejscowosc [nchar](50) NULL,
                Telefon [nchar](50) NULL,
                Email [nchar](50) NULL,
                Aktywny [bit] NULL,
                Nip [nchar](50) NULL,
                Pesel [nchar](50) NULL,
                Dow_seria [nchar](50) NULL,
                Dow_numer [nchar](50) NULL,
                Dow_wydal [nchar](50) NULL,
                Dow_data_wyd [nchar](50) NULL,
                Bank_nazwa [nchar](50) NULL,
                Bank_numer [nchar](50) NULL,
                Zapl_forma [int] NULL,
                Zapl_termin [int] NULL,
                )";
        
        /// <summary>
        /// Sprawdza połączenie z bazą
        /// </summary>
        public void polacz()
        {
            sql = new SqlConnection(connetionString);
            try
            {
                sql.Open();
                MessageBox.Show("Połączenie OK!");
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd! " + ex.Message);
            }
        }

        /// <summary>
        /// tworzy tabelę kontrah w bazie danych
        /// </summary>
        public void tworzTabele()
        {
            sql = new SqlConnection(connetionString);
            try
            {
                sql.Open();
                polecenie = new SqlCommand(zap_tworzenie,sql);
                polecenie.ExecuteNonQuery();
                sql.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Pobiera listę wszystkich kontrahentów z tabeli kontrah
        /// </summary>
        /// <returns>Obiekt DataTable</returns>
        public DataTable pobierz()
        {
            sql = new SqlConnection(connetionString);
            polecenie = new SqlCommand(zap_pobieranie,sql);
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(polecenie);
            DataTable dt = new DataTable();
            sqlDataAdap.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Dodaje kontrahenta do bazy
        /// </summary>
        /// <param name="k">Obiekt Kontrah</param>
        public void dodaj(Kontrah k)
        {
            sql = new SqlConnection(connetionString);
            string zap_dodaj = string.Format("INSERT INTO [kontrah]([Nazwa], [Nazwa_skrocona], [Adr_ulica], [Adr_nr_dom], [Adr_nr_mieszkania], [Adr_kod_pocztowy], [Adr_miejscowosc], [Adrk_ulica], [Adrk_nr_dom], [Adrk_nr_mieszkania], [Adrk_kod_pocztowy], [Adrk_miejscowosc], [Telefon], [Email], [Aktywny], [Nip], [Pesel], [Dow_seria], [Dow_numer], [Dow_wydal], [Dow_data_wyd], [Bank_nazwa], [Bank_numer], [Zapl_forma], [Zapl_termin]) VALUES('{0}', '{1}', '{2}', {3}, {4}, '{5}', '{6}', '{7}', {8}, {9}, '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', {23}, {24})", k.Nazwa, k.Nazwa_skrocona, k.Adr_ulica, k.Adr_nr_dom, k.Adr_nr_mieszkania, k.Adr_kod_pocztowy, k.Adr_miejscowosc, k.Adrk_ulica, k.Adrk_nr_dom, k.Adrk_nr_mieszkania, k.Adrk_kod_pocztowy, k.Adrk_miejscowosc, k.Telefon, k.Email, k.Aktywny, k.Nip, k.Pesel, k.Dow_seria, k.Dow_numer, k.Dow_wydal, k.Dow_data_wyd, k.Bank_nazwa, k.Bank_numer, k.Zapl_forma, k.Zapl_termin);
            sql.Open();
            polecenie = new SqlCommand(zap_dodaj, sql);
            polecenie.ExecuteNonQuery();
            sql.Close();
        }

        /// <summary>
        /// Usuwa kontrahenta o numerze id
        /// </summary>
        /// <param name="i">numer id</param>
        internal void usun(int id)
        {
            sql = new SqlConnection(connetionString);
            sql.Open();
            polecenie = new SqlCommand(zap_usuwanie+id, sql);
            polecenie.ExecuteNonQuery();
            sql.Close();
        }

        internal void edytuj(int id_kontrah, Kontrah k)
        {
            sql = new SqlConnection(connetionString);
            string zap_edytuj = string.Format("UPDATE [kontrah] SET [Nazwa] = '{0}', [Nazwa_skrocona]='{1}', [Adr_ulica]='{2}', [Adr_nr_dom]={3}, [Adr_nr_mieszkania]={4}, [Adr_kod_pocztowy]='{5}', [Adr_miejscowosc]='{6}', [Adrk_ulica]='{7}', [Adrk_nr_dom]={8}, [Adrk_nr_mieszkania]={9}, [Adrk_kod_pocztowy]='{10}', [Adrk_miejscowosc]='{11}', [Telefon]='{12}', [Email]='{13}', [Aktywny]='{14}', [Nip]='{15}', [Pesel]='{16}', [Dow_seria]='{17}', [Dow_numer]='{18}', [Dow_wydal]='{19}', [Dow_data_wyd]='{20}', [Bank_nazwa]='{21}', [Bank_numer]='{22}', [Zapl_forma]={23}, [Zapl_termin]={24} WHERE id={25}", k.Nazwa, k.Nazwa_skrocona, k.Adr_ulica, k.Adr_nr_dom, k.Adr_nr_mieszkania, k.Adr_kod_pocztowy, k.Adr_miejscowosc, k.Adrk_ulica, k.Adrk_nr_dom, k.Adrk_nr_mieszkania, k.Adrk_kod_pocztowy, k.Adrk_miejscowosc, k.Telefon, k.Email, k.Aktywny, k.Nip, k.Pesel, k.Dow_seria, k.Dow_numer, k.Dow_wydal, k.Dow_data_wyd, k.Bank_nazwa, k.Bank_numer, k.Zapl_forma, k.Zapl_termin, id_kontrah);
            sql.Open();
            polecenie = new SqlCommand(zap_edytuj, sql);
            polecenie.ExecuteNonQuery();
            sql.Close();
        }
    }
}
