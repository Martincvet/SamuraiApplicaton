using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Repositories;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamuraiApp.Data.DataSql
{
    public class BattleDataSql : IBattleRepository
    {
        private readonly SamuraiDbContext context;
        public BattleDataSql(SamuraiDbContext context)
        {
            this.context = context;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Battle Create(Battle battle)
        {
            context.Battles.Add(battle);
            return battle;
        }

        public Battle Delete(int battleid)
        {
            var battle = context.Battles.SingleOrDefault(x=>x.Id == battleid);
            if(battle != null)
            {
                context.Battles.Remove(battle);
            }
            return battle;
        }

        public IEnumerable<Battle> GetBattles()
        {
            return context.Battles.ToList();
        }

        public Battle GetBattlesById(int battlesid)
        {
            return context.Battles.SingleOrDefault(x => x.Id == battlesid);
        }

        public Battle Update(Battle Battle)
        {
            context.Entry(Battle).State = EntityState.Modified;
            return Battle;
        }
    }
}
