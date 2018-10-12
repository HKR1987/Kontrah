using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace KontrahenciV2.Model
{
    class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DatabaseContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<Kontrahent> Kontrahenci { get; set; }
    }
}
