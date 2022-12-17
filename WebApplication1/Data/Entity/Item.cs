using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Item
    {
        public int Id { get; set;}
        public int Weight { get; set; }
        public int Price { get; set; }
        public string Quest { get; set; }
        public int Player_Id { get; set; }
       public Player Player { get; set; }
    }
}
