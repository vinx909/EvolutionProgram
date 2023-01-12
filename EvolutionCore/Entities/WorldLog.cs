using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Entities
{
    public class WorldLog : Log
    {
        /// <summary>
        /// Id of the world the log is about
        /// </summary>
        public int WorldId { get; set; }
    }
}
