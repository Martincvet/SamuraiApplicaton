using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.Samurais
{
    public class DeleteModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.ISamuraiRepository repository;

        public DeleteModel(SamuraiApp.Data.Repositories.ISamuraiRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Samurai Samurai { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Samurai = repository.GetSamuraiById(id.Value);

            if (Samurai == null)
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

            Samurai = repository.GetSamuraiById(id.Value);

            if (Samurai != null)
            {
               var delete = repository.Delete(Samurai.Id);
            }

            repository.Commit();
            return RedirectToPage("./Index");
        }
    }
}
