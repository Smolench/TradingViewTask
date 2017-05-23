using System;
using System.Data.Entity;
using SoftFXTestTask.EntityFramework.EntityModels;
using static SoftFXTestTask.EntityFramework.CustomDatas;

namespace SoftFXTestTask.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        static DataBaseContext()
        {
            Database.SetInitializer(new DatabaseContextInitializer());
        }
    }
    class DatabaseContextInitializer : CreateDatabaseIfNotExists<DataBaseContext>
    {
        public static int DaysAmount { get; } = 3;
        public static int Multiplier { get; } = 24;

        protected override void Seed(DataBaseContext db)
        {
            db.Symbols.AddRange(GetSymbols());
            db.SaveChanges();
            
            while(dateTime <= DateTime.Now)
            {
                AddQuotesData(db);
                IncreaseDate();
            }
            db.SaveChanges();
        }
    }
}