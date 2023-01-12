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
    public class GetRandomOrganism : OrganismServiceTestBase
    {
        private const int worldId = 2;
        private const int notWoldId = 3;

        private Organism organism1 = new() { WorldId = worldId, Alive = true };
        private Organism organism2 = new() { WorldId = worldId, Alive = true };
        private Organism organism3 = new() { WorldId = worldId, Alive = false };
        private Organism organism4 = new() { WorldId = notWoldId, Alive = true };

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CallsGetAll(bool mustBeAlive)
        {
            //act
            sut.GetOrganisms(worldId, mustBeAlive).Wait();

            //assert
            mockOrganismRepository.Verify(m => m.GetAll(It.IsAny<Expression<Func<Organism, bool>>>()), Times.Once);
        }

        /// <summary>
        /// can fail randomly due to the random element so worth rerunning
        /// </summary>
        [Fact]
        public void ReturnsAllExpectedOrganismsWhenMustBeAlive()
        {
            //arrange
            Expression<Func<Organism, bool>> query = organism => (organism.WorldId == worldId && organism.Alive == true);
            IEnumerable<Organism> organisms = new Organism[] { organism1, organism2, organism3, organism4 };
            IEnumerable<Organism> expectedOrganisms = new Organism[] { organism1, organism2 };
            mockOrganismRepository.Setup(m => m.GetAll(It.IsAny<Expression<Func<Organism, bool>>>())).Returns(Task.FromResult(filter(organisms, query)));
            List<Organism> results = new();
            List<Organism> expectedResultsLeft = new(expectedOrganisms);

            //act
            for (int i = 0; i < 100; i++)
            {
                results.Add(sut.GetRandomOrganism(worldId, true).Result);
            }

            //assert
            foreach (Organism result in results)
            {
                Assert.Contains(result, expectedOrganisms);
                if (expectedResultsLeft.Contains(result))
                {
                    expectedResultsLeft.Remove(result);
                }
            }
            Assert.Empty(expectedResultsLeft);
        }

        /// <summary>
        /// can fail randomly due to the random element so worth rerunning
        /// </summary>
        [Fact]
        public void ReturnsAllExpectedOrganismsWhenNotMustBeAlive()
        {
            //arrange
            Expression<Func<Organism, bool>> query = organism => (organism.WorldId == worldId);
            IEnumerable<Organism> organisms = new Organism[] { organism1, organism2, organism3, organism4 };
            IEnumerable<Organism> expectedOrganisms = new Organism[] { organism1, organism2, organism3 };
            mockOrganismRepository.Setup(m => m.GetAll(It.IsAny<Expression<Func<Organism, bool>>>())).Returns(Task.FromResult(filter(organisms, query)));
            List<Organism> results = new();
            List<Organism> expectedResultsLeft = new(expectedOrganisms);

            //act
            for (int i = 0; i < 100; i++)
            {
                results.Add(sut.GetRandomOrganism(worldId, false).Result);
            }

            //assert
            foreach (Organism result in results)
            {
                Assert.Contains(result, expectedOrganisms);
                if (expectedResultsLeft.Contains(result))
                {
                    expectedResultsLeft.Remove(result);
                }
            }
            Assert.Empty(expectedResultsLeft);
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
