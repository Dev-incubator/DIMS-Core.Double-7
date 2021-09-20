using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class VUserProfileRepositoryTests
    {
        private readonly VUserProfileRepositoryFixture _repositoryFixture;

        public VUserProfileRepositoryTests()
        {
            _repositoryFixture = new VUserProfileRepositoryFixture();
        }

        [Fact]
        public void GetAll_OK()
        {
            // Act
            var result = _repositoryFixture.Repository
                                           .GetAll()
                                           .ToArray();

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
        
        public void Dispose() => _repositoryFixture.Dispose();
    }
}