using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class Organism
    {
        public int Id { get; set; }
        public string Sequance { get; set; }
        public int Age { get; set; }
        public int NChilderen { get; set; }
        public string Ancestry { get; set; }
    }
}
