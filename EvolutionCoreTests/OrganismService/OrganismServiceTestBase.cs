using EvolutionCore.Entities;
using EvolutionCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionCoreTests.OrganismService
{
    public abstract class OrganismServiceTestBase
    {
        protected readonly IOrganismService sut;
        protected readonly Mock<IRepository<Organism>> mockOrganismRepository;

        public OrganismServiceTestBase()
        {
            mockOrganismRepository = new();
            sut = new EvolutionCore.Services.OrganismService(mockOrganismRepository.Object);
        }
    }
}
