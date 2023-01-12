using EvolutionCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvolutionCoreTests.OrganismService
{
    public class GetOrganisms : OrganismServiceTestBase
    {
        private const int worldId = 2;
        private const int notWoldId = 3;

        private Organism organism1 = new() { WorldId = worldId, Alive = true };
        private Organism organism2 = new() { WorldId = worldId, Alive = true };
        private Organism organism3 = new() { WorldId = worldId, Alive = false };
        private Organism organism4 = new() { WorldId = notWoldId, Alive = true };

        //todo: all GetOrganisms tests
        [Fact]
        public void ReturnsOrganismsFromRepository()
        {
            //arrange
            Expression<Func<Organism, bool>> query = organism => organism.WorldId == worldId;
            IEnumerable<Organism> organisms = new Organism[] { organism1, organism2, organism3, organism4 };
            IEnumerable<Organism> expectedOrganisms = new Organism[] { organism1, organism2, organism3 };
            mockOrganismRepository.Setup(m => m.GetAll(query)).Returns(Task.FromResult(filter(organisms, query)));

            //act
            IEnumerable<Organism> result = sut.GetOrganisms(worldId).Result;

            //assert
            Assert.Equal(expectedOrganisms.Count(), result.Count());
            foreach(Organism expectedOrganism in expectedOrganisms)
            {
                Assert.Contains( expectedOrganism, result);
            }
        }

        private IEnumerable<Organism> filter(IEnumerable<Organism> organisms, Expression<Func<Organism, bool>> query)
        {
            List<Organism> filteredOrganisms = new();
            Func<Organism, bool> queryFunction = query.Compile();
            foreach (var organism in organisms)
            {
                if (queryFunction.Invoke(organism))
                {
                    filteredOrganisms.Add(organism);
                }
            }
            return filteredOrganisms;
        }
    }
}
