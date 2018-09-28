namespace KontrahenciV2.Model
{
    class Polaczenie
    {
    //    private SQLiteConnection _dbConnection = new SQLiteConnection("Data Source=baza.sqlite;Version=3;");
    //    private SQLiteCommand _command;

    //    public void ZapytanieVoid(string zapytanie)
    //    {
    //        try
    //        {
    //            _dbConnection.Open();
    //            _command = new SQLiteCommand(zapytanie, _dbConnection);
    //            _command.ExecuteNonQuery();
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(e.Message);
    //        }
    //        finally
    //        {
    //            _dbConnection.Close();
    //        }
    //    }

    //    public DataSet ZapytanieDataSet(string zapytanie)
    //    {
    //        DataSet ds = new DataSet();

    //        try
    //        {
    //            _dbConnection.Open();
    //            var da = new SQLiteDataAdapter(zapytanie, _dbConnection);
    //            SQLiteCommand command = new SQLiteCommand(zapytanie, _dbConnection);
    //            da.Fill(ds);
    //        }
    //        catch (SQLiteException e)
    //        {
    //            if (e.ErrorCode == 1)
    //            {
    //                MessageBox.Show("Błąd SQLite");
    //            }
    //            else
    //            {
    //                MessageBox.Show(e.Message);
    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(e.Message);
    //        }
    //        finally
    //        {
    //            _dbConnection.Close();
    //        }
    //        return ds;
    //    }


    }
}
