using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class UserTaskRepository : Repository<UserTask>
    {
        public UserTaskRepository(DimsCoreContext context) : base(context) 
        {

        }
    }
}
