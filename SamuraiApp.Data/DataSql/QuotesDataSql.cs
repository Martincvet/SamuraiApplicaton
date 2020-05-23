using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Repositories;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamuraiApp.Data.DataSql
{
    public class QuotesDataSql : IQuotesRepository
    {
        private readonly SamuraiDbContext context;
        public QuotesDataSql(SamuraiDbContext context)
        {
            this.context = context;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Quotes Create(Quotes quotes)
        {
            context.Quotes.Add(quotes); 
            return quotes;
        }

        public Quotes Delete(int quoteid)
        {
            var quote = context.Quotes.SingleOrDefault(x=>x.Id == quoteid);
            if(quote != null)
            {
                context.Quotes.Remove(quote);
            }
            return quote;
        }

        public Quotes GetQuoteById(int id)
        {
            return context.Quotes
                .Include(x => x.Samurai)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Quotes> GetQuotes()
        {
            return context.Quotes
                .Include(x=>x.Samurai)
                .ToList();
        }

        public Quotes Update(Quotes quotes)
        {
            context.Entry(quotes).State = EntityState.Modified;
            return quotes;
        }
    }
}
