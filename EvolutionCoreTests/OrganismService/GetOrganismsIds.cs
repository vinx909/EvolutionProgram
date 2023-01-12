using EvolutionCore.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvolutionCoreTests.OrganismService
{
    public class GetOrganismsIds : OrganismServiceTestBase
    {
        private const int worldId = 2;
        private const int notWoldId = 3;

        private const int id1 = 1;
        private const int id2 = 2;
        private const int id3 = 3;
        private const int id4 = 4;

        private Organism organism1 = new() { Id = id1, WorldId = worldId, Alive = true };
        private Organism organism2 = new() { Id = id2, WorldId = worldId, Alive = true };
        private Organism organism3 = new() { Id = id3, WorldId = worldId, Alive = false };
        private Organism organism4 = new() { Id = id4, WorldId = notWoldId, Alive = true };

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CallsGetAll(bool mustBeAlive)
        {
            //act
            sut.GetOrganismsIds(worldId, mustBeAlive).Wait();

            //assert
            mockOrganismRepository.Verify(m => m.GetAll(It.IsAny<Expression<Func<Organism, bool>>>()), Times.Once);
        }

        [Fact]
        public void ReturnsOrganismIdsFromRepositoryWhenMustBeAlive()
        {
            //arrange
            Expression<Func<Organism, bool>> query = organism => (organism.WorldId == worldId && organism.Alive == true);
            IEnumerable<Organism> organisms = new Organism[] { organism1, organism2, organism3, organism4 };
            IEnumerable<int> expectedOrganismsIds = new int[] { organism1.Id, organism2.Id };
            mockOrganismRepository.Setup(m => m.GetAll(It.IsAny<Expression<Func<Organism, bool>>>())).Returns(Task.FromResult(filter(organisms, query)));

            //act
            IEnumerable<int> result = sut.GetOrganismsIds(worldId, true).Result;

            //assert
            Assert.Equal(expectedOrganismsIds.Count(), result.Count());
            foreach (int expectedOrganism in expectedOrganismsIds)
            {
                Assert.Contains(expectedOrganism, result);
            }
        }

        [Fact]
        public void ReturnsOrganismIdsFromRepositoryWhenNotMustBeAlive()
        {
            //arrange
            Expression<Func<Organism, bool>> query = organism => (organism.WorldId == worldId);
            IEnumerable<Organism> organisms = new Organism[] { organism1, organism2, organism3, organism4 };
            IEnumerable<int> expectedOrganismsIds = new int[] { organism1.Id, organism2.Id, organism3.Id };
            mockOrganismRepository.Setup(m => m.GetAll(It.IsAny<Expression<Func<Organism, bool>>>())).Returns(Task.FromResult(filter(organisms, query)));

            //act
            IEnumerable<int> result = sut.GetOrganismsIds(worldId, true).Result;

            //assert
            Assert.Equal(expectedOrganismsIds.Count(), result.Count());
            foreach (int expectedOrganism in expectedOrganismsIds)
            {
                Assert.Contains(expectedOrganism, result);
            }
        }

        private IEnumerable<Organism> filter(IEnumerable<Organism> organisms, Expression<Func<Organism, bool>> query)
        {
            List<Organism> filteredOrganisms = new();
            foreach (Organism organism in organisms)
            {
                if (query.Compile().Invoke(organism))
                {
                    filteredOrganisms.Add(organism);
                }
            }
            return filteredOrganisms;
        }
    }
}
