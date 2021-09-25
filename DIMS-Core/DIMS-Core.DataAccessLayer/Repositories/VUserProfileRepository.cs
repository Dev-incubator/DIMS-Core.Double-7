using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserProfileRepository : ReadOnlyRepository<VUserProfile>
    {

        public VUserProfileRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}