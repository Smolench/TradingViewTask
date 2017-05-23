using SoftFXTestTask.EntityFramework.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SoftFXTestTask.Services.Repositories
{
    public class QuotesRepository : RepositoryBase<Quote>
    {
        public override Quote Get(int id)
        {
            return _db.Quotes.Include(x => x.Symbol).First();
        }
        public override ICollection<Quote> GetList()
        {
            return _db.Quotes.Include(x => x.Symbol).ToList();
        }
        public override ICollection<Quote> GetList(Func<Quote, bool> where)
        {
            return _db.Quotes.Include(x => x.Symbol).Where(where).ToList();
        }
    }
}