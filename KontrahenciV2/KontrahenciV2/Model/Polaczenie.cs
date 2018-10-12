using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KontrahenciV2.Model
{
    internal class Polaczenie
    {
        private SQLiteConnection _dbConnection = new SQLiteConnection("Data Source=baza.sqlite;Version=3;");
        private SQLiteCommand _command;

        public int ZapytanieZeStatusem(string zapytanie)
        {
            int wynik = 0;
            try
            {
                _dbConnection.Open();
                _command = new SQLiteCommand(zapytanie, _dbConnection);
                wynik =_command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                _dbConnection.Close();
            }
            return wynik;
        }

        public List<Kontrahent> PobierzListeKontrahentow()
        {
            var listaKontrahentow = new List<Kontrahent>();
            throw new NotImplementedException();

        }


    }
}
