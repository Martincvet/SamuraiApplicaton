using SamuraiApp.Data;
using SamuraiApp.Data.Repositories;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamuraiApp.Bussines
{
    public class War
    {
        private readonly SamuraiDbContext context;
        private readonly SamuraiApp.Data.Repositories.IBattleRepository repo;

        public War( SamuraiDbContext context, SamuraiApp.Data.Repositories.IBattleRepository repo)
        {
            this.context = context;
            this.repo = repo;
        }

        public int TotalSamurais()
        {
            return context.Samurais.Count();
        }

        public int KatanaSolders()
        {
            return context.Samurais.Select(x=>x.Wepon == Wepons.katana).Count(); 
        }

        public int TotalBattles()
        {
            return context.Battles.Count();
        }
        public int TotalBattlesinPlace(string place)
        {
            return context.Battles.Select(x => x.Place == place).Count();
        }

        public int TotalQuotes()
        {
            return context.Quotes.Count();
        }

        public double TotalTimeofBattle(Battle battle)
        {
            var startdate = battle.StartDate;
            var enddate = battle.EndDate;
            var temp = new TimeSpan();
            temp = enddate.Subtract(startdate);
            return temp.TotalDays;
        }

        public double TotalTimeofWar()
        {
            var battlestart = repo.GetBattlesById(1);
            var nesho = battlestart.StartDate;

            var battleend = repo.GetBattles().Max();
            var temp = battleend.EndDate;

            var temporary = new TimeSpan();
            temporary = nesho.Subtract(temp);
            return temporary.TotalDays;
        }

    }
}
