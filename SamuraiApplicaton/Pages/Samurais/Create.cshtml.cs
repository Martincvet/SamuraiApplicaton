using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApplicaton.Pages.Samurais
{
    public class CreateModel : PageModel
    {
        private readonly SamuraiApp.Data.Repositories.ISamuraiRepository repository;
        private readonly IHtmlHelper htmlHelper;

        public CreateModel(SamuraiApp.Data.Repositories.ISamuraiRepository repository, IHtmlHelper htmlHelper)
        {
            this.repository = repository;
            this.htmlHelper = htmlHelper;
        }
        [BindProperty]
        public Samurai Samurai { get; set; }
        public IEnumerable<SelectListItem> Wepon { get; set; }
        public IActionResult OnGet()
        {
            Samurai = new Samurai();
            Wepon = htmlHelper.GetEnumSelectList<Wepons>();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Samurai.Id == 0)
                {
                    Samurai = repository.Create(Samurai);
                }
                else
                {
                    Samurai = repository.Update(Samurai);
                }

                repository.Commit();
                return RedirectToPage("./Index");
            }
            Wepon = htmlHelper.GetEnumSelectList<Wepons>();

            return Page();
        }
    }
}
