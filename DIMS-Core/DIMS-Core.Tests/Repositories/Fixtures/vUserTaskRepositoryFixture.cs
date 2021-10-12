using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserTaskRepositoryFixture : ViewRepositoryFixture<VUserTaskRepository>
    {
        protected override VUserTaskRepository CreateRepository() => new(Context);
    }
}