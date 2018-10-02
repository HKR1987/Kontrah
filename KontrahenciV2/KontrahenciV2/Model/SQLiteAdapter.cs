using System.Collections.Generic;
using System.Data.SQLite;

namespace KontrahenciV2.Model
{
    public static class SQLiteAdapter
    {

        public static bool DodajKontrahenta(Kontrahent kontrahent)
        {
            return false;
        }

        public static Kontrahent PobierzKontrahenta(int id)
        {
            return new Kontrahent();
        }

        public static List<Kontrahent> PobierzListeKontrahentow()
        {

            return new List<Kontrahent>();
        }
    }
}
