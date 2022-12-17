using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Armor
    {
        public int Id { get; set;}
        public Armor_Class Class { get; set; }
        public Armor_type Type { get; set; }
        public int Defecne { get; set; }
        public int Weight { get; set; }        
        public int Player_Id { get; set; }
        public Player Player { get; set; }
        public int Enchantment_Id { get; set; }
        public Enchantment Enchantment { get; set; }

        public enum Armor_Class
        { 
            Тяжелая, Легкая        
        }

        public enum Armor_type
        { 
            Шлем, Нагрудник, Перчатки, Сапоги, Щит
        }
    }
}
