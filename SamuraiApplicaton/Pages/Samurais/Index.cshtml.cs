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
    public class IndexModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.ISamuraiRepository _context;

        public IndexModel(SamuraiApp.Data.Repositories.ISamuraiRepository context)
        {
            _context = context;
        }

        public IEnumerable<Samurai> Samurais { get;set; }

        public void OnGet()
        {
            Samurais = _context.GetSamurais();
        }
    }
}
