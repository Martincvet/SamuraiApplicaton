using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.Battle
{
    public class CreateModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IBattleRepository repository;

        public CreateModel(SamuraiApp.Data.Repositories.IBattleRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public SamuraiApp.Domain.Battle Battle { get; set; }
        public IActionResult OnGet()
        {
            Battle = new SamuraiApp.Domain.Battle();
            if(Battle.Id != 0)
            {
                return RedirectToPage("./Edit");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Battle.Id == 0)
            {
                Battle = repository.Create(Battle);
            }
            else
            {
                Battle = repository.Update(Battle);
            }

            repository.Commit();
            return RedirectToPage("./Index");
        }
    }
}
