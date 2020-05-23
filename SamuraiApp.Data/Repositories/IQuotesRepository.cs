using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data.Repositories
{
    public interface IQuotesRepository
    {
        IEnumerable<Quotes> GetQuotes();
        Quotes GetQuoteById(int id);
        Quotes Create(Quotes quotes);
        Quotes Update(Quotes quotes);
        Quotes Delete(int quoteid);
        int Commit();
    }
}
