using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class Organism : IdEntity
    {
        /// <summary>
        /// Id of the world the organism exists in
        /// </summary>
        public int WorldId { get; set; }
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
        /// the id of the parent
        /// </summary>
        public int? ParentId => parentId;
        /// <summary>
        /// the age of the world when the world started
        /// </summary>
        public int BirthWorldAge => birthWorldAge;

        private readonly int? parentId;
        private readonly int birthWorldAge;
    }
}
