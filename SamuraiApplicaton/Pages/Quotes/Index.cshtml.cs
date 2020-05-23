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
    public class IndexModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.IQuotesRepository _context;

        public IndexModel(SamuraiApp.Data.Repositories.IQuotesRepository context)
        {
            _context = context;
        }

        public IEnumerable<SamuraiApp.Domain.Quotes> Quotes { get;set; }

        public void OnGet()
        {
            Quotes = _context.GetQuotes();
        }
    }
}
