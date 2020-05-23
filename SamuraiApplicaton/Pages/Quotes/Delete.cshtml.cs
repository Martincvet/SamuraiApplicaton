using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.Quotes
{
    public class DeleteModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IQuotesRepository repository;

        public DeleteModel(SamuraiApp.Data.Repositories.IQuotesRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public SamuraiApp.Domain.Quotes Quote { get; set; }

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

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();                                   
            }

            Quote = repository.GetQuoteById(id.Value);
         
            if (Quote != null)
            {
                repository.Delete(Quote.Id);
            }
            repository.Commit();
            return RedirectToPage("./Index");
        }
    }
}
