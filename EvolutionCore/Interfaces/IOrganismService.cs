using EvolutionCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Interfaces
{
    public interface IOrganismService
    {
        /// <summary>
        /// gets a list with all ids of all organisms of the given world
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns>a list of int of all the ids of organisms</returns>
        public List<int> GetOrganismsIds(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// gets a random organisms id
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns>the int of the id of a random organism</returns>
        public int GetRandomOrganismId(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns></returns>
        public List<Organism> GetOrganisms(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns></returns>
        public Organism GetRandomOrganism(int idWorld, bool mustBeAlive = true);
        public Organism GetOrganism(int id);
        public void RunOrganism(int idOrganism);
        public void RunOrganism(Organism organism);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        public void RunAllOrganisms(int idWorld);
    }
}
