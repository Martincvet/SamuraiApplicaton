using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.Battle
{
    public class DeleteModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IBattleRepository repository;

        public DeleteModel(SamuraiApp.Data.Repositories.IBattleRepository repository)
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Battle = repository.GetBattlesById(id.Value);

            if (Battle != null)
            {
                Battle = repository.Delete(Battle.Id);
            }

            repository.Commit();
            return RedirectToPage("./Index");
        }
    }
}
