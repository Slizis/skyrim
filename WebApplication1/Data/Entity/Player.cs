using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Player
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Level { get; set; }
        public ICollection<Armor> Armors { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Scream> Screams { get; set; }
        public ICollection<Perks> Perks { get; set; }
        public ICollection<Quest> Quests { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public ICollection<Talent> Talents { get; set; }
        public ICollection<Weapon> Weapons { get; set; }

    }
}
