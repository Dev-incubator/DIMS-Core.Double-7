using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserProgressFixture : ViewRepositoryFixture<VUserProgressRepository>
    {
        protected override VUserProgressRepository CreateRepository() => new(Context);
    }
}