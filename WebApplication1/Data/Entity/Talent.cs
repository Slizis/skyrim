using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Talent
    {
        public int Id { get; set;}
        public string Talent_name { get; set;}
        public string Talent_type { get; set; }
        public int Duration { get; set; }
        public int Player_Id { get; set; }
        public Player Player { get; set; }
      
    }
}
