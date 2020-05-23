using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamuraiApp.Bussines
{
    public class Class
    {
        private readonly SamuraiDbContext _context;
        public Class(SamuraiDbContext _context)
        {
            this._context = _context;
        }
        //public void Posledna()
        //{
        //    var samurais = _context.Samurais
        //        .Where(s => s.Battles.Count == 2)
        //        .ToList();
        //    foreach (var samurai in samurais)
        //    {
        //        Console.WriteLine($"Battles number: {samurai.Battles.Count}");
        //        Console.WriteLine($"Samurai`s Name: {samurai.Name}");
        //        Console.WriteLine($"SicretIdentity: {samurai.SecretIdentity}, a Real Name: {samurai.SecretIdentity.RealName}");
        //    }
        //}
        //public static void UpdateSamuraiBattlesObject()
        //{
        //    Domain.Samurai samurai;
        //    using (var db = new SamuraiDbContext())
        //    {
        //        samurai = db.Samurais.Single(s => s.Id == 11);
        //    }

        //    var samuraiBattles = new List<SamuraiBattle>
        //    {
        //        new SamuraiBattle {SamuraiId = 14},
        //        new SamuraiBattle {SamuraiId = 15}
        //    };

        //    using (var db2 = new SamuraiDbContext())
        //    {
        //        db2.SamuraiBattles.AddRange(samuraiBattles);
        //        db2.SaveChanges();
        //    }
        //}
        //public void Neshoglupo()
        //{
        //    var samurai = _context.Samurais.Include(s => s.Quotes).Single(s => s.Id == 14);
        //    var quote = samurai.Quotes.First();
        //    quote.Text += "Drugo";

        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Entry(quote).State = EntityState.Deleted;
        //        db.SaveChanges();
        //    }
        //}

        //#region Domashna
        ////Додадете нов самурај со 3 изреки(Quote) и SecretIdentity
        //public static void AddingNewSamurai()
        //{
        //    var samurai = new Domain.Samurai
        //    {
        //        Name = "Stole",
        //        Quotes = new List<Quotes>
        //        {
        //            new Quotes { Text = "Quote1" },
        //            new Quotes { Text = "Quote2" },
        //            new Quotes { Text = "Quote3" },
        //        },
        //        SecretIdentity = new SecretIdentity { RealName = "Jacko" },
        //    };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(samurai);
        //        db.SaveChanges();
        //    }

        //}
        ////Додаете нова битка во која учествувал самурајот со Id = 11 i еден нов самурај кој има Quote и SecretIdentity а и учествувал во битката со id = 1
        //public static void InsertSamuraiBattle()
        //{
        //    var battle = new Battle
        //    {
        //        SamuraiBattles = new List<SamuraiBattle> { new SamuraiBattle { SamuraiId = 11 } }
        //    };
        //    var samurai = new Domain.Samurai
        //    {
        //        Name = "Saturo",
        //        Quotes = new List<Quotes> { new Quotes { Text = "Quote1" } },
        //        Battles = new List<SamuraiBattle> { new SamuraiBattle { SamuraiId = 1 } },
        //        SecretIdentity = new SecretIdentity { RealName = "Neo" }
        //    };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(samurai);
        //        db.Battles.Add(battle);
        //        db.SaveChanges();
        //    }

        //}
        ////Додадете на битката со id = 1 самураите со Id = 2 и Id = 10(со object tracking и discontinued scenario)
        //public void InsertUpdateBattle()
        //{
        //    _context.Battles.Add(new Battle
        //    {
        //        Id = 1,
        //        SamuraiBattles = new List<SamuraiBattle>
        //            {
        //                new SamuraiBattle{SamuraiId = 2},
        //                new SamuraiBattle{SamuraiId = 10}
        //            },

        //    });
        //    _context.SaveChanges();
        //}
        ////Испринтајте на екран: Сите самураи со нивните изреки и тајни идентитеити кои биле во битката со име = [Name]
        //public void PrintingSamurai()
        //{
        //    var samurais = _context.Samurais
        //        .Include(s => s.Quotes)
        //        .Include(s => s.SecretIdentity)
        //        .Where(s => s.Battles.Any(p => p.Battle.Name == "Kung Fu"))
        //        .ToList();

        //    foreach (var samurai in samurais)
        //    {
        //        Console.WriteLine($"Samurai: {samurai.Name} and his Secretidentity: {samurai.SecretIdentity}");
        //        foreach (var item in samurai.Quotes)
        //        {
        //            Console.WriteLine($"Quotes: {item.Text}");
        //        }
        //    }
        //}
        ////Испринтајте на екран: Само име на самурај од quote само quote и RealName од SecretIdentity и бројот на битки во кој бил
        //public void PrintSamuraiQuoteBattle()
        //{
        //    var samurais = _context.Samurais
        //        .Include(s => s.Quotes)
        //        .Include(s => s.Battles.Count())
        //        .ToList();

        //    foreach (var samurai in samurais)
        //    {
        //        Console.WriteLine($"Samurai`s Name: {samurai.Name}");
        //        foreach (var item in samurai.Quotes)
        //        {
        //            Console.WriteLine($"Quote: {item.Text}");
        //        }
        //        Console.WriteLine($"SecretIdentity: {samurai.SecretIdentity?.RealName}");
        //    }
        //}
        ////Испринтајте на екран: само името на самурајот и неговиот таен идентитет кои учествувале во 2 битки
        //#endregion

        //#region InsertPart
        //public void InsertSamurai()
        //{

        //    var samurai1 = new Domain.Samurai();
        //    samurai1.Name = "Kire";

        //    var samurai = new Domain.Samurai();
        //    samurai.Name = "Petar";

        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(samurai1);
        //        db.Add(samurai);

        //        db.SaveChanges();
        //    }
        //}
        //public void InsertMultipleSamurai()
        //{
        //    var list = new List<Domain.Samurai>();
        //    var sam1 = new Domain.Samurai();
        //    sam1.Name = "Kire";

        //    var sam2 = new Domain.Samurai();
        //    sam1.Name = "Petar";

        //    list.Add(sam1);
        //    list.Add(sam2);
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.AddRange(sam1, sam2);
        //        db.Samurais.AddRange(list);
        //        db.AddRange(sam1, sam2);

        //        db.SaveChanges();
        //    }

        //}
        //public void InsertDiffObj()
        //{
        //    var sam = new Domain.Samurai
        //    {
        //        Name = "Name1"
        //    };
        //    var bat = new Battle
        //    {
        //        Name = "Belasica",
        //        StartDate = DateTime.Today.AddDays(-30),
        //        EndDate = DateTime.Today
        //    };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.AddRange(sam, bat);
        //        db.SaveChanges();
        //    }

        //}
        //public void InsertSamurai1()
        //{
        //    var samurai = new Domain.Samurai { Name = "Kire" };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(samurai);
        //        db.SaveChanges();
        //    }
        //}
        //public void InsertBattle()
        //{
        //    _context.Battles.Add(new Battle
        //    {
        //        Name = "Battle of Okehazama",
        //        StartDate = new DateTime(1560, 05, 01),
        //        EndDate = new DateTime(1560, 06, 15)
        //    });
        //    _context.SaveChanges();
        //}
        //public void InsertNewPkFkGraph()
        //{
        //    var samurai = new Domain.Samurai
        //    {
        //        Name = "Kambei Shimado",
        //        Quotes = new List<Quotes>
        //        {
        //            new Quotes { Text = "I`ve come to save you!"}
        //        }
        //    };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}
        //public void InsertMultipleSamurais()
        //{
        //    var samurai = new Domain.Samurai { Name = "Mile" };
        //    var drugsamurai = new Domain.Samurai { Name = "Sashe" };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.AddRange(samurai, drugsamurai);
        //        db.SaveChanges();
        //    }
        //}
        //public void InsertMultipleSamuraisViaBatch()
        //{
        //    var samurai1 = new Domain.Samurai { Name = "Samurai1" };
        //    var samurai2 = new Domain.Samurai { Name = "Samurai2" };
        //    var samurai3 = new Domain.Samurai { Name = "Samurai3" };
        //    var samurai4 = new Domain.Samurai { Name = "Samurai4" };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.AddRange(samurai1, samurai2, samurai3, samurai4);
        //        db.SaveChanges();
        //    }
        //}
        //public void InsertNewPkFkGraphMultipleChildren() // parent and children
        //{
        //    var samurai = new Domain.Samurai
        //    {
        //        Name = "Kali Jahnn",
        //        Quotes = new List<Quotes> // samurajot e parent, quotes se decata
        //        {
        //            new Quotes { Text = "Watch out from your blade." },
        //            new Quotes { Text = "I told you before what to do now!"}
        //        }
        //    };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}
        //#endregion

        //#region AddingPart
        //private void AddingMoreSamurais()
        //{
        //    _context.AddRange(
        //        new Domain.Samurai { Name = "Kambei Shimaga" },
        //        new Domain.Samurai { Name = "Saito Lee" },
        //        new Domain.Samurai { Name = "Yujiro Hanma" },
        //        new Domain.Samurai { Name = "Kuze" },
        //        new Domain.Samurai { Name = "Gorombei Hayashida" },
        //        new Domain.Samurai { Name = "Saichi Katamaya" });
        //    _context.SaveChanges();
        //}
        //private void AddQuote()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var s = db.Samurais.Single(s => s.Id == 11);
        //        s.Quotes.Add(new Quotes { Text = "Kje Mu ja udram edna" });
        //        s.Quotes.Add(new Quotes { Text = "Drugi put pak" });
        //        db.SaveChanges();
        //    }

        //}
        //private void AddQuote3()
        //{
        //    var quote = new Quotes
        //    {
        //        Text = "Hohoho",
        //        SamuraiId = 11
        //    };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Quotes.Add(quote);
        //        db.SaveChanges();
        //    }
        //}
        //private void AddQuoteDrugVid()
        //{
        //    var s = new Domain.Samurai();
        //    s.Name = "Stojan";
        //    s.Quotes.Add(new Quotes
        //    {
        //        Text = "Jurish Mothefuckers "
        //    }
        //    );
        //    s.Quotes.Add(new Quotes { Text = "Odime Jako" });

        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(s);
        //        db.SaveChanges();
        //    }
        //}
        //private void AddChildToExistingObjectWhileTracked()
        //{
        //    var samurai = _context.Samurais.First();
        //    samurai.Quotes.Add(new Quotes
        //    {
        //        Text = "I bet that you`re happy that i saved you."
        //    });
        //    _context.SaveChanges();
        //}
        //private static void AddChildToExcistingObjectWhileNotTracked(int samuraiId)
        //{
        //    var qoute = new Quotes
        //    {
        //        Text = "Now i`m glad to hear that, will you help me now?",
        //        SamuraiId = samuraiId
        //    };
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Quotes.Add(qoute);
        //        db.SaveChanges();
        //    }
        //}
        //#endregion

        //#region QueriesPart
        //public static void QuerySamurai()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var temp = "Kire";
        //        var samurais = db.Samurais.Where(s => s.Name == temp).ToList();
        //        foreach (var samurai in samurais)
        //        {
        //            Console.WriteLine($"{samurai.Id} {samurai.Name}");
        //        }

        //        // var samurai = samurai.Where(s => s.Id == 1).Single();
        //        var sam = samurais.SingleOrDefault(s => s.Id == 1);
        //        Console.WriteLine($"Samurai: {sam.Id} {sam.Name}");
        //    }

        //}
        //public static void MoreQueries()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var samurai_NonParameterizedQuery = db.Samurais.Where(s => s.Name == "Sashe").ToList();
        //        var name = "Sampson";
        //        var samurai_ParameterizedQuery = db.Samurais.Where(s => s.Name == name).ToList();
        //        var samurai_Object = db.Samurais.FirstOrDefault(s => s.Name == name);
        //        var samurais_ObjectFindByKeyValue = db.Samurais.Find(2);
        //        var samuraisJ = db.Samurais.Where(s => EF.Functions.Like(s.Name, "K%")).ToList();
        //        var search = "K%";
        //        var samuraisParameter = db.Samurais.Where(s => EF.Functions.Like(s.Name, search)).ToList();
        //    }
        //}
        //private static void LinqQuery()
        //{
        //    using (var nesho = new SamuraiDbContext())
        //    {
        //        var query = from s in nesho.Samurais
        //                    where EF.Functions.Like(s.Name, "S%")
        //                    select s;
        //        var temp = query.ToList();
        //    }
        //}

        //#endregion

        //#region UpdatePart
        //private void UpdateSamurai()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(new Domain.Samurai { Name = "Temporary" });
        //        var sl = db.Samurais.SingleOrDefault(s => s.Id == 1);
        //        if (sl != null)
        //        {
        //            sl.Name = "san" + sl.Name;
        //        }
        //        db.SaveChanges();
        //    }
        //}
        //public void SimpleSamuraiQuery()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var samurais = db.Samurais.ToList();
        //        //var query = db.Samurais;
        //        //var samuraiagain = query.ToList();
        //        foreach (var samurai in db.Samurais)
        //        {
        //            Console.WriteLine(samurai.Name);
        //        }
        //    }
        //}
        //public void UpdateSamurai2() // dovolno e samo savechanges zasho e update i pravi tracking na se stho se sluchuva
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Add(new Domain.Samurai { Name = "Samurai" });
        //        var s1 = db.Samurais.SingleOrDefault(s => s.Id == 1);
        //        if (s1 != null)
        //        {
        //            s1.Name = "San" + s1.Name;
        //        }
        //        db.SaveChanges();
        //    }

        //}
        //private void UpdateMultipleSamurai()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var samurais = db.Samurais.Where(s => EF.Functions.Like(s.Name, "S%")).ToList();
        //        foreach (var samurai in samurais)
        //        {
        //            samurai.Name = "San" + samurai.Name;
        //        }
        //        db.SaveChanges();
        //    }

        //}
        //public void UppdateDisconnectedObj()
        //{
        //    Domain.Samurai samurai;
        //    using (var db = new SamuraiDbContext())
        //    {
        //        samurai = db.Samurais.Single(s => s.Id == 4);
        //    }

        //    samurai.Name = "Dis" + samurai.Name;
        //    using (var nesho = new SamuraiDbContext())
        //    {
        //        nesho.Samurais.Update(samurai);
        //        nesho.SaveChanges();
        //    }
        //}
        //private void QueryAndUpdateBattle_Disconnected()
        //{
        //    var battle = _context.Battles.FirstOrDefault(); //dodavam kaj samurajot vo negovata bitka enddata
        //    battle.EndDate = new DateTime(1566, 06, 30);
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Battles.Update(battle);
        //        db.SaveChanges();
        //    }
        //}
        //private void QueryAndUpdateSamurai_Disconnected()
        //{
        //    var sam = _context.Samurais.FirstOrDefault(s => s.Name == "Kikuchiyo");
        //    sam.Name += "San";
        //    using (var db = new SamuraiDbContext())
        //    {
        //        db.Samurais.Update(sam);
        //        db.SaveChanges();
        //    }
        //}
        //public void RetriveAndUpdateSamurai()
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var samurai = db.Samurais.FirstOrDefault();
        //        samurai.Name += "San";
        //        db.SaveChanges();
        //    }
        //}
        //public void RetriveAndUpdateMultipleSamurais()
        //{
        //    //using (var db = new SamuraiDbContext())
        //    //{
        //    var samurais = _context.Samurais.ToList();
        //    samurais.ForEach(s => s.Name += " Sam");
        //    _context.SaveChanges();
        //    //}

        //}
        //#endregion

        //#region DeletePart
        //private void DeleteSamurai()
        //{
        //    Domain.Samurai s;
        //    using (var db = new SamuraiDbContext())
        //    {
        //        s = db.Samurais.First(s => EF.Functions.Like(s.Name, "S%"));
        //    }

        //    using (var nesho = new SamuraiDbContext())
        //    {
        //        nesho.Samurais.Remove(s);
        //        nesho.SaveChanges();
        //    }
        //}
        //private void DeleteSamuraiDisscontinued()
        //{
        //    Domain.Samurai s;
        //    using (var db = new SamuraiDbContext())
        //    {
        //        s = db.Samurais.First(s => EF.Functions.Like(s.Name, "s%"));
        //    }

        //    using (var dr = new SamuraiDbContext())
        //    {
        //        dr.Samurais.Remove(s);
        //        //dr.Database.ExecuteSqlCommand("exec DeleteSamurai @Id", s.Id); // za 
        //        dr.SaveChanges();
        //    }
        //}
        //private void DeleteWhileTracked()
        //{
        //    var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Kambei Shimada");
        //    _context.Samurais.Remove(samurai);
        //    //some alternatives:
        //    //_context.Remove(samurai);
        //    //_context.Samurais.Remove(_context.Samurais.Find(1));
        //    _context.SaveChanges();
        //}
        //private void DeleteWhileNotTracked()
        //{
        //    var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Kuze");
        //    _context.Entry(samurai).State = EntityState.Deleted;
        //    _context.SaveChanges();
        //}
        //private void DeleteMany()
        //{
        //    var samurais = _context.Samurais.Where(s => s.Name.Contains("o"));
        //    _context.Samurais.RemoveRange(samurais);
        //    _context.RemoveRange(samurais);
        //    _context.SaveChanges();
        //}
        //private void DeleteUsingId(int samuraid)
        //{
        //    var samurai = _context.Samurais.Find(samuraid);
        //    _context.Remove(samurai);
        //    _context.SaveChanges();
        //    //_context.Database.ExecuteSqlCommand("exec DeleteById {0}", samuraid);
        //}

        //#endregion

        //#region GetPart
        //private void GetSamuraiwithQuotes() // leftjoin
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var samurais = db.Samurais.Include(s => s.Quotes).Where(s => EF.Functions.Like(s.Name, "S%")).ToList();
        //        foreach (var samuraj in samurais)
        //        {
        //            Console.WriteLine($"{samuraj.Id} {samuraj.Name}");
        //            Console.WriteLine(".............................................");
        //            foreach (var quote in samuraj.Quotes)
        //            {
        //                Console.WriteLine($"{quote.Id} {quote.Text} {quote.SamuraiId}");
        //            }
        //        }
        //    }
        //}
        //private void GetQuotes() //innerjoin
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var quotes = db.Quotes.Include(s => s.SamuraiId).Where(p => EF.Functions.Like(p.Text, "Q%")).ToList();
        //        foreach (var quote in quotes)
        //        {
        //            Console.WriteLine($"Samurai: {quote.Samurai.Name} -- {quote.Text}");
        //        }
        //    }
        //}
        //private void GetSamuraiQuote() //select object (koga nema kade da se stavi, nemozhe da se povika od database, )
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        var result = db.Samurais.Select(s => new { SamName = s.Name, QuotesCount = s.Quotes.Count() }).ToList();
        //        foreach (var item in result)
        //        {
        //            Console.WriteLine($"{item.SamName} : Count : {item.QuotesCount}");
        //        }
        //    }
        //}
        //public void GetSamuraiwithSpecificQuote() //select object razlika (da se upotrebi  za posle tamu kade kje bide potrebno)
        //{
        //    using (var db = new SamuraiDbContext())
        //    {
        //        //var result = db.Samurais
        //        //    .Where(s => s.Quotes.Any(q => EF.Functions.Like(q.Text, "S%")))
        //        //    .Select(s => new SamuraiQuote { SamName = s.Name, QuotesCount = s.Quotes.Count() })
        //        //    .OrderBy(s => s.SamName)
        //        //    .GroupBy(s => s.QuotesCount)
        //        //    .ToList();

        //        var result2 = db.Samurais
        //            .Include(x => x.Quotes) // netreba vaka bidejki ne e efikasno, kje gi zeme site od memorija
        //            .GroupBy(s => s.Name)
        //            .Select(x => new { GroupName = x.Key, QuoteQount = x.Sum(y => y.Quotes.Count()) })
        //            .ToList();

        //        foreach (var item in result2)
        //        {
        //            Console.WriteLine($"{item.GroupName} : Count : {item.QuoteQount}");
        //        }

        //        //foreach (var item in result)
        //        //{
        //        //    Console.WriteLine($"{item.SamName} : Count : {item.QuotesCount}");
        //        //}
        //    }
        //}
        //#endregion

        ////Sintaksichka greshka ili Greshka vo preveduvanjeto od c# vo sql jazik
        //public void ProjectSomeProperties()
        //{
        //    var someProperties = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
        //    var idsAndNames = _context.Samurais.Select(s => new IdandName(s.Id, s.Name)).ToList();
        //}

        //public void ProjectSamuraisWithQuotes()
        //{
        //    var somePropertieswithOptions = _context.Samurais
        //        .Select(s => new { s.Id, s.Name, s.Quotes.Count })
        //        .ToList();
        //}

        //private void FilteringWithRelatedData()
        //{
        //    var samurais = _context.Samurais
        //        .Where(s => s.Quotes.Any(q => q.Text.Contains("happy")))
        //        .ToList();
        //}
        //public class IdandName
        //{
        //    public string Name;
        //    public int Id;
        //    public IdandName(int id, string name)
        //    {
        //        Id = id;
        //        Name = name;
        //    }
        //}
        //public class SamuraiQuote
        //{
        //    public string SamName { get; set; }
        //    public int QuotesCount { get; set; }
        //}

    }
}
