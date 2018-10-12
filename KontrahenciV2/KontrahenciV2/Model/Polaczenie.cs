using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KontrahenciV2.Model
{
    internal class Polaczenie
    {
        private static SQLiteConnection _dbConnection = new SQLiteConnection("Data Source=baza.sqlite;Version=3;");
        private static SQLiteCommand _command;

        private int ZapytanieZeStatusem(string zapytanie)
        {
            var wynik = 0;
            using (_dbConnection)
            {
                try
                {
                    _dbConnection.Open();
                    _command = new SQLiteCommand(zapytanie, _dbConnection);
                    wynik = _command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return wynik;
        }

        public static List<Kontrahent> PobierzListeKontrahentow()
        {
            var listaKontrahentow = new List<Kontrahent>();
            throw new NotImplementedException();
        }

        public static int DodajKontrahenta(Kontrahent kontrahent)
        {
            var wynik = 0;
            var zapytanie = $"INSERT INTO Kontrahent " +
                    $"(nazwa, nazwaSkrocona, nip, regon, telefon, email, status, formaZaplaty, terminZaplaty) VALUES " +
                    $"('{kontrahent.Nazwa}','{kontrahent.NazwaSkrocona}','{kontrahent.Nip}','{kontrahent.Regon}','{kontrahent.Telefon}'," +
                    $"'{kontrahent.Email}', {(int)kontrahent.Status}, {(int)kontrahent.FormaZaplaty}, {kontrahent.TerminZaplaty})";

            try
            {
                _dbConnection.Open();
                _command = new SQLiteCommand(zapytanie, _dbConnection);
                wynik = _command.ExecuteNonQuery();
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
    }
}
