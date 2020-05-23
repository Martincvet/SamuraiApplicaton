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

namespace SamuraiApplicaton.Pages.Quotes
{
    public class EditModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IQuotesRepository repository;
        private readonly SamuraiApp.Data.Repositories.ISamuraiRepository samurairepo;

        public EditModel(SamuraiApp.Data.Repositories.IQuotesRepository repository, SamuraiApp.Data.Repositories.ISamuraiRepository samurairepo)
        {
           this.repository = repository;
            this.samurairepo = samurairepo;
        }

        [BindProperty]
        public SamuraiApp.Domain.Quotes Quote { get; set; }
        public IEnumerable<SelectListItem> Samurais { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = repository.GetQuoteById(id.Value);

            if (Quote == null)
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
                Quote = repository.GetQuoteById(Quote.Id);

                if(Quote.Id != 0)
                {
                    Quote = repository.Update(Quote);
                }
                else
                {
                    return RedirectToPage("./Create");
                }

                repository.Commit();
                return RedirectToPage("./Index");
            }
            var list = samurairepo.GetSamurais().ToList().Select(x => new { Id = x.Id, SamuraiName = $"{x.Name}" });
            Samurais = new SelectList(list, "Id", "SamuraiName");
            return Page();
        }

        private bool QuotesExists(int id)
        {
            return repository.GetQuotes().Any(x => x.Id == id);
        }
    }
}
