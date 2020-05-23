using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data.Repositories
{
    public interface ISamuraiRepository
    {
        IEnumerable<Samurai> GetSamurais(string searchSamurai = null);
        Samurai GetSamuraiById(int samuraiId);
        Samurai Create(Samurai samurai);
        Samurai Update(Samurai samurai);
        Samurai Delete(int id);
        int Commit();
    }
}
