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

namespace SamuraiApplicaton.Pages.Battle
{
    public class EditModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IBattleRepository repository;

        public EditModel(SamuraiApp.Data.Repositories.IBattleRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public SamuraiApp.Domain.Battle Battle { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Battle = repository.GetBattlesById(id.Value);

            if (Battle == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Battle.Id != 0)
            {
                Battle = repository.Update(Battle);
            }
            else
            {
                return RedirectToPage("./Create");
            }

            repository.Commit();
            return RedirectToPage("./Index");
        }
    }
}
