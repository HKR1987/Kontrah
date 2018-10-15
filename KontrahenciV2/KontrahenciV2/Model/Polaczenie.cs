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

        internal List<Kontrahent> PobierzListeKontrahentow()
        {
            var zapytanie = $"SELECT id, nazwa, nazwaSkrocona, nip, regon, telefon, email, status FROM Kontrahent";
            var listaKontrahentow = new List<Kontrahent>();
            try
            {
                _dbConnection.Open();
                _command = new SQLiteCommand(zapytanie, _dbConnection);
                SQLiteDataReader reader = _command.ExecuteReader();
                while(reader.Read())
                {
                    listaKontrahentow.Add(new Kontrahent {
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
