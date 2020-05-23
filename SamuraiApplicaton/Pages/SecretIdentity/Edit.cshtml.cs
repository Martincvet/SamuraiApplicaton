using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.SecretIdentity
{
    public class EditModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.ISecretIdentityRepository repo;
        private readonly SamuraiApp.Data.Repositories.ISamuraiRepository samurairepo;

        public EditModel(SamuraiApp.Data.Repositories.ISecretIdentityRepository repo, SamuraiApp.Data.Repositories.ISamuraiRepository samurairepo)
        {
            this.repo = repo;
            this.samurairepo = samurairepo;
        }

        [BindProperty]
        public SamuraiApp.Domain.SecretIdentity SecretIdentity { get; set; }
        public IEnumerable<SelectListItem> Samurais { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                SecretIdentity = new SamuraiApp.Domain.SecretIdentity();
            }

            SecretIdentity = repo.GetSecretIdentity(id.Value);

            if (SecretIdentity == null)
            {
                return NotFound();
            }
            var list = samurairepo.GetSamurais().ToList().Select(x => new { Id = x.Id, SamuraiName = $"{x.Name}" });
            Samurais = new SelectList(list, "Id", "SamuraiName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(SecretIdentity.Id == 0)
                {
                    SecretIdentity = repo.Create(SecretIdentity);
                }
                else
                {
                    SecretIdentity = repo.Update(SecretIdentity);
                }
                
                repo.Commit();
                return RedirectToPage("./Index");
            }
            var list = samurairepo.GetSamurais().ToList().Select(x => new { Id = x.Id, SamuraiName = $"{x.Name}" });
            Samurais = new SelectList(list, "Id", "SamuraiName");
            return Page();
        }
    }
}
