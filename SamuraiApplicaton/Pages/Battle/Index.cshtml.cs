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
    public class IndexModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IBattleRepository _context;

        public IndexModel(SamuraiApp.Data.Repositories.IBattleRepository context)
        {
            _context = context;
        }

        public IEnumerable<SamuraiApp.Domain.Battle> Battles { get;set; }

        public void OnGet()
        {
            Battles = _context.GetBattles();
        }
    }
}
