using Microsoft.EntityFrameworkCore;
using Task = DIMS_Core.DataAccessLayer.Models.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskRepository : Repository<Task>
    {
        public TaskRepository(DbContext context) : base(context)
        {
        }
    }
}