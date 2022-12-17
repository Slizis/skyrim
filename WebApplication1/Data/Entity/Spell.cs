using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Spell
    {
        public int Id { get; set; }
        public string Spell_name { get; set; }
        public int MP_cost { get; set; }

        public int Player_Id { get; set; }
        public Player Player { get; set; }
        public int NPC_Id { get; set; }
        public NPC NPC { get; set; }

       
    }
}
