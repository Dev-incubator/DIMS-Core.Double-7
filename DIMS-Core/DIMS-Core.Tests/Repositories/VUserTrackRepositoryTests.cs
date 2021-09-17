using System;
using System.Threading.Tasks;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;

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
        // Note: GetAll will work always in our case. It can be thrown into EF Core.
        // But it is implementation details of EF Core so we mustn't test these cases.
        public async Task GetAll_OK()
        {
            // Act
            var result = await _repositoryFixture.Repository
                                                 .GetAll()
                                                 .ToArrayAsync();

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
        
        public void Dispose() => _repositoryFixture.Dispose();

    }
}