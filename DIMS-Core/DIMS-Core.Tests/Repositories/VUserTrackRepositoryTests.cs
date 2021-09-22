using System;
using System.Threading.Tasks;
using DIMS_Core.Tests.Repositories.Fixtures;
using Xunit;
using System.Linq;

namespace DIMS_Core.Tests.Repositories
{
    public class VUserTrackRepositoryTests : IDisposable
    {
        private readonly VUserTrackRepositoryFixture _repositoryFixture;

        public VUserTrackRepositoryTests()
        {
            _repositoryFixture = new VUserTrackRepositoryFixture();
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