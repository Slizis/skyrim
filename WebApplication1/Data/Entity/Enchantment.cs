using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Enchantment
    {
        public int Id { get; set; }
        public string Ench_name { get; set; }
        public Ench_Type Type { get; set; }
        public int Duration { get; set; }
        public ICollection<Enchantment> Enchantments { get; set; }

        public enum Ench_Type
        { 
        Активное,Пассивное
        }
    }
}
