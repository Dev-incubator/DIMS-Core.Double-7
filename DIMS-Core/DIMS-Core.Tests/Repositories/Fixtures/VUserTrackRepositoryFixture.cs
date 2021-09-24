using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserTrackRepositoryFixture : ViewRepositoryFixture<VUserTrackRepository>
    {
        public override VUserTrackRepository Repository => new(Context);
    }
}