using DIMS_Core.Tests.Repositories.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.Repositories
{
    class UserTaskRepositoryTests : IDisposable
    {
        private readonly UserTaskRepositoryFixture _fixture;

        public UserTaskRepositoryTests()
        {
            _fixture = new UserTaskRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
