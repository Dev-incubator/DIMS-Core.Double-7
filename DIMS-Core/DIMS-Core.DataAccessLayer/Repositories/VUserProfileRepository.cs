using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserProfileRepository : ReadOnlyRepository<VUserProfile>
    {
        protected VUserProfileRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}