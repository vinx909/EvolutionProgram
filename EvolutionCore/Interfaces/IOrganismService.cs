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
        /// gets an organism with the given ID
        /// </summary>
        /// <param name="idOrganism">id of the organism to get</param>
        /// <returns></returns>
        public Task<Organism> GetOrganism(int idOrganism);
        /// <summary>
        /// gets a list of organisms from the give world
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns></returns>
        public Task<IEnumerable<Organism>> GetOrganisms(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// gets a list with all ids of all organisms of the given world
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns>a list of int of all the ids of organisms</returns>
        public Task<IEnumerable<int>> GetOrganismsIds(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// gets a random organism
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns></returns>
        public Task<Organism> GetRandomOrganism(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// gets a random organisms id
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        /// <param name="mustBeAlive">if the organisms need to be alive, by default set to true</param>
        /// <returns>the int of the id of a random organism</returns>
        public Task<int> GetRandomOrganismId(int idWorld, bool mustBeAlive = true);
        /// <summary>
        /// do a full tick for every organism
        /// </summary>
        /// <param name="idWorld">the id of the world the organisms need to belong to</param>
        public Task RunAllOrganisms(int idWorld);
        /// <summary>
        /// do a full tick for an organism with this id
        /// </summary>
        /// <param name="idOrganism">id of the organism to get</param>
        public Task RunOrganism(int idOrganism);
        /// <summary>
        /// do a full tick for this organism
        /// </summary>
        /// <param name="organism">organism to run</param>
        public Task RunOrganism(Organism organism);
    }
}
