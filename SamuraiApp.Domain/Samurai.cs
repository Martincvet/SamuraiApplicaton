using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public Samurai()
        {
            Quotes = new List<Quotes>();
        }
        public string Name { get; set; }
        public List<Quotes> Quotes { get; set; }
        //public int BattleId { get; set; }
        public List<SamuraiBattle> Battles { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        public Wepons Wepon { get; set; }
    }
}
