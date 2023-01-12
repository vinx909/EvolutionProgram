using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class World : IdEntity
    {
        /// <summary>
        /// amount of food in the world
        /// </summary>
        public int NFood { get; set; }
        /// <summary>
        /// age of the world
        /// </summary>
        public int Age { get; set; }
    }
}
