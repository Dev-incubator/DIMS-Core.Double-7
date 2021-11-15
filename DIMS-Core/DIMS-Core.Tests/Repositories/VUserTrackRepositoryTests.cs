using System;
using DIMS_Core.Tests.Repositories.Fixtures;
using Xunit;
using System.Linq;

namespace DIMS_Core.Tests.Repositories
{
    public class VUserTrackRepositoryTests : IDisposable
    {
        private readonly VUserTrackRepositoryFixture _fixture;

        public VUserTrackRepositoryTests()
        {
            _fixture = new VUserTrackRepositoryFixture();
        }

        [Fact]
        public void GetAll_OK()
        {
            // Act
            var result = _fixture.Repository
                                 .GetAll()
                                 .ToArray();

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
        
        public void Dispose() => _fixture.Dispose();
    }
}