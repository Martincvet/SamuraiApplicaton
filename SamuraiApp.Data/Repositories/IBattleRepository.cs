using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data.Repositories
{
    public interface IBattleRepository
    {
        IEnumerable<Battle> GetBattles();
        Battle GetBattlesById(int battlesid);
        Battle Update(Battle battle);
        Battle Create(Battle battle);
        Battle Delete(int battleid);
        int Commit();
    }
}
