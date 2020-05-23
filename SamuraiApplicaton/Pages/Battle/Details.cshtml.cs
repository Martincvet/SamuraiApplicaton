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
    public class DetailsModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IBattleRepository repository;

        public DetailsModel(SamuraiApp.Data.Repositories.IBattleRepository repository)
        {
            this.repository = repository;
        }

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
    }
}
