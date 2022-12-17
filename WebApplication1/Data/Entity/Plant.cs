using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Plant
    { 
        public int Id { get; set; }
        public string Effect { get; set; }
        public int Weight { get; set; }
         public int Biom_Id { get; set; }
        public Biom Biom { get; set; }
    }
}
