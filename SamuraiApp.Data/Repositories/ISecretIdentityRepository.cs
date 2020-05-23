using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data.Repositories
{
    public interface ISecretIdentityRepository
    {
        IEnumerable<SecretIdentity> GetSecretIdentities(string search = null);
        SecretIdentity Create(SecretIdentity secretIdentity);
        SecretIdentity Update(SecretIdentity secretIdentity);
        SecretIdentity GetSecretIdentity(int id);
        SecretIdentity Delete(int secretIdentityById);
        int Commit();
    }
}
