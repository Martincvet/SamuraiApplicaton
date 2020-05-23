using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.SecretIdentity
{
    public class IndexModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.ISecretIdentityRepository repo;

        public IndexModel(SamuraiApp.Data.Repositories.ISecretIdentityRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<SamuraiApp.Domain.SecretIdentity> SecretIdentities { get;set; }

        public void OnGet()
        {
            SecretIdentities = repo.GetSecretIdentities();
        }
    }
}
