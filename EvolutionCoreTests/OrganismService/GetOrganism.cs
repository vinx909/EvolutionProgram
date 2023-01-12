using EvolutionCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvolutionCoreTests.OrganismService
{
    public class GetOrganism : OrganismServiceTestBase
    {
        [Fact]
        public void ReturnsOrganismFromRepository()
        {
            //arrange
            const int organismsId = 4;
            Organism organism = new Organism() { Id = organismsId};
            mockOrganismRepository.Setup(m => m.Get(organismsId)).Returns(Task.FromResult(organism));

            //act
            Organism result = sut.GetOrganism(organismsId).Result;

            //assert
            Assert.Equal(organism, result);
        }

        [Fact]
        public void ReturnsNullIfResultFromRepositoryIsNull()
        {
            //arrange
            const int organismsId = 4;
            mockOrganismRepository.Setup(m => m.Get(organismsId)).Returns(Task.FromResult<Organism>(null));

            //act
            Organism result = sut.GetOrganism(organismsId).Result;

            //assert
            Assert.Null(result);
        }
    }
}
