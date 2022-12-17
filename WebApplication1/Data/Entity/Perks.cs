using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Perks
    {
        public int Id {get; set;}
        public int access_lvl { get; set; }
        public Class_perk Class { get; set; }
        public string Effect { get; set; }
        public int Player_Id { get; set; }
        public Player Player { get; set;}

        public enum Class_perk
        { 
        Воин, Маг, Разбойник
        }
       
    }
}
