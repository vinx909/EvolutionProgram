using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class OrganismLog : Log
    {
        /// <summary>
        /// Id of the organism the log is about
        /// </summary>
        public int IdOrganism { get; set; }
    }
}
