using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class World
    {
        /// <summary>
        /// the Id of the world. purely relavent so the correct world can be called for
        /// </summary>
        public int Id { get; set; }
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
