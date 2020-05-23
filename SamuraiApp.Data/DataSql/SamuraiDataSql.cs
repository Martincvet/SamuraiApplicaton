using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Repositories;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamuraiApp.Data.DataSql
{
    public class SamuraiDataSql : ISamuraiRepository
    {
        private readonly SamuraiDbContext _context;
        public SamuraiDataSql(SamuraiDbContext _context)
        {
            this._context = _context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Samurai Create(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            return samurai;
        }

        public Samurai Delete(int id)
        {
            var Samurai = _context.Samurais.SingleOrDefault(x => x.Id == id);
            if (Samurai != null)
            {
                _context.Samurais.Remove(Samurai);
            }
            return Samurai;
        }

        public Samurai GetSamuraiById(int samuraiId)
        {
            return _context.Samurais.SingleOrDefault(x => x.Id == samuraiId);
        }

        public IEnumerable<Samurai> GetSamurais(string searchSamurai)
        {
            return _context.Samurais
                .Include(x => x.Quotes)
                .Include(x => x.Battles)
                .ToList();
        }

        public Samurai Update(Samurai samurai)
        {
            _context.Entry(samurai).State = EntityState.Modified;
            return samurai;
        }
    }
}
