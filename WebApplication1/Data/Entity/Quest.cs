using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Quest
    {
        public int Id { get; set; }
        public string Receving { get; set; }
        public int acess_lvl { get; set; }
        public int Recewing { get; set; }
        public int NPC_Id { get; set; }
        public NPC NPC { get; set; }
        public int Player_Id {get; set;}
        public Player Player { get; set; }

      
    }
}
