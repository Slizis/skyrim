using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Biom
    {
        public int Id { get; set; }
        public string Biom_Name { get; set; }
        public string Location { get; set; }
        public Biom_weather Weather { get; set; }
        public ICollection<Plant> Plants { get; set;}
        public ICollection<NPC> NPCs { get; set; }

        public enum Biom_weather
        { 
        Ветренно, Дождь, Ливень, Метель, Снегопад, Норма
        }

    }
}
