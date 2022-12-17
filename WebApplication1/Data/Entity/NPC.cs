using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class NPC
    {
        public int Id { get; set; }
        public string NPC_name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public string Fraction { get; set; }
        public int Biom_Id { get; set; }
       public Biom Biom { get; set; }

        public ICollection<NPC> NPCs { get; set; }


        
    }
}
