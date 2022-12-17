using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Weapon_class { get; set; }
        public string Weapon_type { get; set; }
        public int Weight { get; set; }
        public int Player_Id { get; set; }
        public Player Player { get; set; }
        public int Enchantment_Id { get; set; }
        public Enchantment Enchantment { get; set; }
    }
}
