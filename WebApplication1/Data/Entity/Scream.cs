using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Scream
    {
        public int Id { get; set; }
        public string Type_Scream { get; set; }
        public int Damage { get; set; }
        public int Duration { get; set; }
        public int Player_Id { get; set; }
        public Player Player { get; set; }
    }
}
