using System;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.Common.Exceptions;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class VTaskRepositoryTests : IDisposable
    {
        private readonly VTaskRepositoryFixture _repositoryFixture;

        public VTaskRepositoryTests()
        {
            _repositoryFixture = new VTaskRepositoryFixture();
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