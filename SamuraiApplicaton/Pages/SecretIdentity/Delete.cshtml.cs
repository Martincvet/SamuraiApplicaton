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
    public class DeleteModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.ISecretIdentityRepository repo;

        public DeleteModel(SamuraiApp.Data.Repositories.ISecretIdentityRepository repo)
        {
            this.repo = repo;
        }

        [BindProperty]
        public SamuraiApp.Domain.SecretIdentity SecretIdentity { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SecretIdentity = repo.GetSecretIdentity(id.Value);

            if (SecretIdentity == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SecretIdentity = repo.GetSecretIdentity(id.Value);

            if (SecretIdentity != null)
            {
                SecretIdentity = repo.Delete(SecretIdentity.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
