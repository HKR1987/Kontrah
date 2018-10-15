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

        private int ZapytanieZeStatusem(string zapytanie)
        {
            var wynik = 0;
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

        internal Kontrahent PobierzKontrahenta(int id)
        {

            var zapytanie = $"SELECT id, nazwa, nazwaSkrocona, nip, regon, telefon, email, status, formaZaplaty, terminZaplaty FROM Kontrahent WHERE id={id} LIMIT 1";
            Kontrahent kontrahent = null;

            try
            {
                _dbConnection.Open();
                kontrahent = TworzenieKontrahenta(zapytanie);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                _dbConnection.Close();
            }
            return kontrahent;
        }

        private Kontrahent TworzenieKontrahenta(string zapytanie)
        {

            _command = new SQLiteCommand(zapytanie, _dbConnection);
            SQLiteDataReader reader = _command.ExecuteReader();
            Kontrahent kontrahent = null;
            while (reader.Read())
            {
                kontrahent = new Kontrahent
                {
                    Id = Int32.Parse(reader["id"].ToString()),
                    Nazwa = reader["nazwa"].ToString(),
                    NazwaSkrocona = reader["nazwaSkrocona"].ToString(),
                    Nip = reader["nip"].ToString(),
                    Regon = reader["regon"].ToString(),
                    Telefon = reader["telefon"].ToString(),
                    Email = reader["email"].ToString(),
                    Status = (Status)Int32.Parse(reader["status"].ToString()),
                    FormaZaplaty = (FormaZaplaty)Int32.Parse(reader["formaZaplaty"].ToString()),
                    TerminZaplaty = Int32.Parse(reader["terminZaplaty"].ToString())
                };
            }
                
            
            return kontrahent;
        }

        internal List<Kontrahent> PobierzListeKontrahentow()
        {
            var zapytanie = $"SELECT id, nazwa, nazwaSkrocona, nip, regon, telefon, email, status FROM Kontrahent";
            var listaKontrahentow = new List<Kontrahent>();
            try
            {
                TworzenieListyKontrahentow(zapytanie, listaKontrahentow);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                _dbConnection.Close();
            }
            return listaKontrahentow;
        }

        internal void ZapiszKontrahenta(Kontrahent kontrahent, int id)
        {
            var zapytanie = $"UPDATE Kontrahent SET nazwa = '{kontrahent.Nazwa}', nazwaSkrocona = '{kontrahent.NazwaSkrocona}', " +
                $"nip = '{kontrahent.Nip}', regon = '{kontrahent.Regon}', telefon = '{kontrahent.Telefon}', " +
                $"email = '{kontrahent.Email}', status = {(int)kontrahent.Status}, formaZaplaty = {(int)kontrahent.FormaZaplaty}, " +
                $" terminZaplaty = {kontrahent.TerminZaplaty} WHERE id = {id}";

            try
            {
                _dbConnection.Open();
                _command = new SQLiteCommand(zapytanie, _dbConnection);
                _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        private void TworzenieListyKontrahentow(string zapytanie, List<Kontrahent> listaKontrahentow)
        {
            _dbConnection.Open();
            _command = new SQLiteCommand(zapytanie, _dbConnection);
            SQLiteDataReader reader = _command.ExecuteReader();
            while (reader.Read())
            {
                listaKontrahentow.Add(new Kontrahent
                {
                    Id = Int32.Parse(reader["id"].ToString()),
                    Nazwa = reader["nazwa"].ToString(),
                    NazwaSkrocona = reader["nazwaSkrocona"].ToString(),
                    Nip = reader["nip"].ToString(),
                    Regon = reader["regon"].ToString(),
                    Telefon = reader["telefon"].ToString(),
                    Email = reader["email"].ToString(),
                    Status = (Status)Int32.Parse(reader["status"].ToString())
                });
            }
        }

        internal void UsunKontrahenta(int id)
        {
            ZapytanieZeStatusem($"DELETE FROM Kontrahent where id={id}");
        }

        internal int DodajKontrahenta(Kontrahent kontrahent)
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
