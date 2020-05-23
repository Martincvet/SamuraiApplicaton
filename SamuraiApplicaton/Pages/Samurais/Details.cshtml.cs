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
    public class DetailsModel : PageModel
    {
        private readonly SamuraiApp.Data.SamuraiDbContext _context;

        public DetailsModel(SamuraiApp.Data.SamuraiDbContext context)
        {
            _context = context;
        }

        public Samurai Samurai { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Samurai = await _context.Samurais.FirstOrDefaultAsync(m => m.Id == id);

            if (Samurai == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
