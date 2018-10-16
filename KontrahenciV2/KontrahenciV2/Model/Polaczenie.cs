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
                kontrahent.KontoBankowe = PobranieKonta(kontrahent.Id);
                kontrahent.AdresSiedziby = PobranieAdresu(TypAdresu.siedziby, kontrahent.Id);
                kontrahent.AdresKorespondencyjny = PobranieAdresu(TypAdresu.korespondencyjny, kontrahent.Id);
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

        private Adres PobranieAdresu(TypAdresu typ, int id)
        {
            var zapytanie = $"SELECT idKontrahenta, miejscowosc, ulica, nrDomu, nrMieszkania, kodPocztowy, Typ FROM Adres WHERE " +
                            $"idKontrahenta={id} AND typ = {(int)typ} LIMIT 1";
            _command = new SQLiteCommand(zapytanie, _dbConnection);
            SQLiteDataReader reader = _command.ExecuteReader();
            Adres adres = null;
            while (reader.Read())
            {
                adres = new Adres(Int32.Parse(reader["idKontrahenta"].ToString()), reader["miejscowosc"].ToString(), 
                            reader["ulica"].ToString(), reader["nrDomu"].ToString(), reader["nrMieszkania"].ToString(), reader["kodPocztowy"].ToString());
            }
            return adres;
        }

        private KontoBankowe PobranieKonta(int id)
        {
            var zapytanie = $"SELECT idKontrahenta, nazwa, numer FROM KontoBankowe WHERE idKontrahenta={id} LIMIT 1";
            _command = new SQLiteCommand(zapytanie, _dbConnection);
            SQLiteDataReader reader = _command.ExecuteReader();
            KontoBankowe kontoBankowe = null;
            while (reader.Read())
            {
                kontoBankowe = new KontoBankowe(Int32.Parse(reader["idKontrahenta"].ToString()), reader["nazwa"].ToString(), reader["numer"].ToString());
            }
            return kontoBankowe;
        }

        private Kontrahent TworzenieKontrahenta(string zapytanie)
        {

            _command = new SQLiteCommand(zapytanie, _dbConnection);
            SQLiteDataReader reader = _command.ExecuteReader();
            Kontrahent kontrahent = new Kontrahent();
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

        internal void AktualizujKontrahenta(Kontrahent kontrahent, int id)
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
                AktualizujKontoBankowe(id, kontrahent.KontoBankowe);
                AktualizujAdres(id, TypAdresu.siedziby, kontrahent.AdresSiedziby);
                AktualizujAdres(id, TypAdresu.korespondencyjny, kontrahent.AdresKorespondencyjny);
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

        private void AktualizujAdres(int id, TypAdresu typAdresu, Adres adres)
        {
            var zapytanie = $"UPDATE Adres SET miejscowosc = '{adres.Miejscowosc}', ulica = '{adres.Ulica}', nrDomu = '{adres.NrDomu}', " +
                            $"nrMieszkania = '{adres.NrMieszkania}', kodPocztowy = '{adres.KodPocztowy}' WHERE idKontrahenta = {id} " +
                            $"AND typ = {(int)typAdresu}";
            _command = new SQLiteCommand(zapytanie, _dbConnection);
            _command.ExecuteNonQuery();
        }

        private void AktualizujKontoBankowe(int id, KontoBankowe kontoBankowe)
        {
            var zapytanie = $"UPDATE KontoBankowe SET nazwa = '{kontoBankowe.Nazwa}', numer = '{kontoBankowe.Numer}' WHERE idKontrahenta = {id}";
            _command = new SQLiteCommand(zapytanie, _dbConnection);
            _command.ExecuteNonQuery();
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
            ZapytanieZeStatusem($"DELETE FROM KontoBankowe where idKontrahenta={id}");
            ZapytanieZeStatusem($"DELETE FROM Adres where idKontrahenta={id}");
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
                kontrahent.Id = kontrahent.AdresSiedziby.IdKontrahenta = kontrahent.AdresKorespondencyjny.IdKontrahenta = kontrahent.KontoBankowe.IdKontrahenta = PobierzId();
                DodajAdres(TypAdresu.siedziby, kontrahent.AdresSiedziby);
                DodajAdres(TypAdresu.korespondencyjny, kontrahent.AdresKorespondencyjny);
                DodajKontoBankowe(kontrahent.KontoBankowe);
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

        private int PobierzId()
        {
            var zapytanie = $"SELECT last_insert_rowid()";
            var ostatnieId = 0;

            _command = new SQLiteCommand(zapytanie, _dbConnection);
            ostatnieId = Int32.Parse(_command.ExecuteScalar().ToString());

            return ostatnieId;
        }

        private void DodajAdres (TypAdresu typ, Adres adres)
        {
            var zapytanie = $"INSERT INTO Adres (idKontrahenta, miejscowosc, ulica, nrDomu, nrMieszkania, kodPocztowy, Typ) VALUES" +
                             $"({adres.IdKontrahenta}, '{adres.Miejscowosc}', '{adres.Ulica}', '{adres.NrDomu}', '{adres.NrMieszkania}', " +
                             $"'{adres.KodPocztowy}', {(int)typ})";

            _command = new SQLiteCommand(zapytanie, _dbConnection);
            _command.ExecuteNonQuery();
        }

        private void DodajKontoBankowe(KontoBankowe konto)
        {
            var zapytanie = $"INSERT INTO KontoBankowe (idKontrahenta, nazwa, numer) VALUES" +
                            $"({konto.IdKontrahenta}, '{konto.Nazwa}', '{konto.Numer}')";

            _command = new SQLiteCommand(zapytanie, _dbConnection);
            _command.ExecuteNonQuery();
        }
    }
}
