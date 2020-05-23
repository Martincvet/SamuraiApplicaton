using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IQuotesRepository repository;
        private readonly SamuraiApp.Data.Repositories.ISamuraiRepository samurairepo;

        public CreateModel(SamuraiApp.Data.Repositories.IQuotesRepository repository, SamuraiApp.Data.Repositories.ISamuraiRepository samurairepo)
        {
            this.repository = repository;
            this.samurairepo = samurairepo;
        }

        [BindProperty]
        public SamuraiApp.Domain.Quotes Quote { get; set; }
        public IEnumerable<SelectListItem> Samurais { get; set; }

        public IActionResult OnGet()
        {
            if(Quote.Id != 0)
            {
                return RedirectToPage("./Edit");
            }

            Quote = new SamuraiApp.Domain.Quotes();

            var list = samurairepo.GetSamurais().ToList().Select(x => new { Id = x.Id, SamuraiName = $"{x.Name}" });
            Samurais = new SelectList(list, "Id", "SamuraiName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Quote.Id == 0)
            {
                Quote = repository.Create(Quote);
            }

            repository.Commit();
            var list = samurairepo.GetSamurais().ToList().Select(x => new { Id = x.Id, SamuraiName = $"{x.Name}" });
            Samurais = new SelectList(list, "Id", "SamuraiName");
            return RedirectToPage("./Index");
        }
    }
}
