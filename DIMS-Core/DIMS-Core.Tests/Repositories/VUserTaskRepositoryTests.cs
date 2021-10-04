using DIMS_Core.Tests.Repositories.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class VUserTaskRepositoryTests : IDisposable
    {
        private readonly VUserTaskRepositoryFixture _fixture;

        public VUserTaskRepositoryTests()
        {
            _fixture = new VUserTaskRepositoryFixture();
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
