using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SamuraiApplicaton.Pages.War
{
    public class IndexModel : PageModel
    {
        private readonly SamuraiApp.Bussines.War war;
        public IndexModel(SamuraiApp.Bussines.War war)
        {
            this.war = war;
        }

        public SamuraiApp.Domain.Battle Battle { get; set; }

        public int GetTotalSamurais()
        {
            return war.TotalSamurais();
        }

        public int GetTotalKatanaSolders()
        {
            return war.KatanaSolders();
        }

        public int GetTotalBattles()
        {
            return war.TotalBattles();
        }

        public int GetTotalQuotes()
        {
            return war.TotalQuotes();
        }

        public double GetTotalTimeOfWar()
        {
            return war.TotalTimeofWar();
        }
    }
}
