using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ModelTask = DIMS_Core.DataAccessLayer.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskRepository : Repository<ModelTask>
    {
        private readonly DatabaseFacade _database;
        
        public TaskRepository(DimsCoreContext context) : base(context)
        {
            _database = GetDb();
        }
        public Task DeleteTask(int taskId)
        {
            return _database.ExecuteSqlRawAsync("exec [dbo].[Tasks] @taskId", new SqlParameter("@taskId", taskId));
        }
    }
}