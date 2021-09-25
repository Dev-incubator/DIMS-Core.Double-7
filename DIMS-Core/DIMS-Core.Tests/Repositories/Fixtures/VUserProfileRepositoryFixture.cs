using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserProfileRepositoryFixture : ViewRepositoryFixture<VUserProfileRepository>
    {
        protected override VUserProfileRepository CreateRepository() => new(Context);
    }
}