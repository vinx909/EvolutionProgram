using EvolutionCore.Entities;
using EvolutionCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCore.Services
{
    public class OrganismService : IOrganismService
    {
        private IRepository<Organism> organismRepository;

        public OrganismService(IRepository<Organism> organismRepository)
        {
            this.organismRepository = organismRepository;
        }

        public async Task<Organism> GetOrganism(int idOrganism)
        {
            return await organismRepository.Get(idOrganism);
        }

        public async Task<IEnumerable<Organism>> GetOrganisms(int idWorld, bool mustBeAlive = true)
        {
            if (mustBeAlive)
            {
                return await organismRepository.GetAll(o => o.WorldId == idWorld && o.Alive == true);
            }
            else
            {
                return await organismRepository.GetAll(o => o.WorldId == idWorld);
            }
        }

        public async Task<IEnumerable<int>> GetOrganismsIds(int idWorld, bool mustBeAlive = true)
        {

            IEnumerable<Organism> organisms = await GetOrganisms(idWorld, mustBeAlive);
            int[] ids = new int[organisms.Count()];
            int index = 0;
            foreach (Organism organism in organisms)
            {
                ids[index] = organism.Id;
                index++;
            }
            return ids;
        }

        public async Task<Organism> GetRandomOrganism(int idWorld, bool mustBeAlive = true)
        {
            //todo: ! GetRandomOrganism functionality
            throw new NotImplementedException();
        }

        public async Task<int> GetRandomOrganismId(int idWorld, bool mustBeAlive = true)
        {
            //todo: ! GetRandomOrganismId functionality
            throw new NotImplementedException();
        }

        public async Task RunAllOrganisms(int idWorld)
        {
            //todo: ! RunAllOrganisms functionality
            throw new NotImplementedException();
        }

        public async Task RunOrganism(int idOrganism)
        {
            //todo: ! RunOrganism(int) functionality
            throw new NotImplementedException();
        }

        public async Task RunOrganism(Organism organism)
        {
            //todo: ! RunOrganism(Organism) funtionality
            throw new NotImplementedException();
        }
    }
}
