using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrahenci
{
    class Polaczenie
    {
        static string serwer = "ACER\\SQLEXPRESS";
        static string baza = "test";
        static string uzytkownik = "sa";
        static string haslo = "sa@";
        string connetionString = "Data Source="+serwer+";Initial Catalog="+baza+";User ID="+uzytkownik+";Password="+haslo;
        SqlConnection sql;
        SqlCommand polecenie;
        string zap_tworzenie = @"
                CREATE TABLE [test2](
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


       

            public void polacz()
        {
            sql = new SqlConnection(connetionString);
            try
            {
                sql.Open();
                MessageBox.Show("Success!");
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd! " + ex.Message);
            }
        }

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


        public void pobierz()
        {

        }



    }
}
