using EvolutionCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Interfaces
{
    internal interface IWorldService
    {
        public int[] GetWorldsIds(bool mustBeAlive = true);
        public World[] GetWorlds(bool mustBeAlive = true);
        public World GetWorld(int id);
        public void RunWorld();
        public void RunWorld(int timesToRun);
    }
}
