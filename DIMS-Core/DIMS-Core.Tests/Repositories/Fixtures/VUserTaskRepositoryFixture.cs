using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserTaskRepositoryFixture : ViewRepositoryFixture<VUserTaskRepository>
    {
        protected override VUserTaskRepository CreateRepository() => new(Context);
    }
}
