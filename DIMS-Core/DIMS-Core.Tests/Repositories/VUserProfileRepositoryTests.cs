using System;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class VUserProfileRepositoryTests : IDisposable
    {
        private readonly VUserProfileRepositoryFixture _fixture;

        public VUserProfileRepositoryTests()
        {
            _fixture = new VUserProfileRepositoryFixture();
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