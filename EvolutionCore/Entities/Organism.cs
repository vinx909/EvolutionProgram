using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class Organism
    {
        /// <summary>
        /// the Id of the organism. purely relavent so the correct organism can be called for
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id of the world the organism exists in
        /// </summary>
        public int IdWorld { get; set; }
        /// <summary>
        /// the sequance that defines the features of the organism
        /// </summary>
        public string Sequence { get; set; }
        /// <summary>
        /// the number of time intervals the organism has survived for
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// defines if the Organism is still alive
        /// </summary>
        public bool Alive { get; set; }
        /// <summary>
        /// defines how many childeren the organism has had
        /// </summary>
        public int NChilderen { get; set; }
        /// <summary>
        /// keeps track of all parents of the organism
        /// </summary>
        public string Ancestry { get; set; }
    }
}
