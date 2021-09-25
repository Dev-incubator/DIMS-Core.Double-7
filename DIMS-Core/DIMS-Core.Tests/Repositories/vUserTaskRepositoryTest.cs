using DIMS_Core.Tests.Repositories.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class vUserTaskRepositoryTest : IDisposable
    {
        private readonly vUserTaskRepositoryFixture _fixture;

        public vUserTaskRepositoryTest()
        {
            _fixture = new vUserTaskRepositoryFixture();
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
