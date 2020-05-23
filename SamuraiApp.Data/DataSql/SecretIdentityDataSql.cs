using SamuraiApp.Data.Repositories;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamuraiApp.Data.DataSql
{
    public class SecretIdentityDataSql : ISecretIdentityRepository
    {
        private readonly SamuraiDbContext context;
        public SecretIdentityDataSql(SamuraiDbContext context)
        {
            this.context = context;
        }
        public int Commit()
        {
            return context.SaveChanges();
        }

        public SecretIdentity Create(SecretIdentity secretIdentity)
        {
            context.SecretIdentities.Add(secretIdentity);
            return secretIdentity;
        }

        public SecretIdentity Delete(int secretIdentityId)
        {
            var tempsecretIdentity = context.SecretIdentities.SingleOrDefault(x => x.Id == secretIdentityId);
            if (tempsecretIdentity != null)
            {
                context.SecretIdentities.Remove(tempsecretIdentity);
            }
            return tempsecretIdentity;
        }

        public IEnumerable<SecretIdentity> GetSecretIdentities(string search)
        {
            return context.SecretIdentities.Where(x => x.RealName == search.ToLower()).ToList();
        }

        public SecretIdentity GetSecretIdentity(int id)
        {
            return context.SecretIdentities.SingleOrDefault(x => x.Id == id);
        }

        public SecretIdentity Update(SecretIdentity secretIdentity)
        {
            context.Entry(secretIdentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return secretIdentity;
        }
    }
}
