using DIMS_Core.DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskStateRepository : Repository<TaskState>
    {
        private readonly DatabaseFacade _database;
        public TaskStateRepository(DimsCoreContext context) : base(context) 
        {
            _database = GetDb(); 
        }

        public Task SetUserTaskAsSuccess(int userId, int taskId)
        {
            return _database.ExecuteSqlRawAsync("exec [dbo].[SetUserTaskAsSuccess] @userId, @taskId", new SqlParameter("userId", userId), new SqlParameter("@taskId", taskId));
        }

        public Task SetUserTaskAsFail(int userId, int taskId)
        {
            return _database.ExecuteSqlRawAsync("exec [dbo].[SetUserTaskAsFail] @userId, @taskId", new SqlParameter("userId", userId), new SqlParameter("@taskId", taskId));
        }
    }
}
