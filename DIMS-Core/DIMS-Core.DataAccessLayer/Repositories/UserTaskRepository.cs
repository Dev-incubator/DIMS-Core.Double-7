using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class UserTaskRepository : Repository<UserTask>
    {
        public UserTaskRepository(DbContext context) : base(context) { }
    }
}
