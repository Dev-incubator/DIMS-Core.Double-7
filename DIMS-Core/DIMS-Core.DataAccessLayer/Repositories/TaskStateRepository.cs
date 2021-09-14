using DIMS_Core.DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskStateRepository : Repository<TaskState>
    {
        public TaskStateRepository(DbContext context) : base(context) { }

        public Task SetUserTaskAsSuccess(int userId,int taskId)
        {
            return _context.Database.ExecuteSqlRawAsync("exec [dbo].[SetUserTaskAsSuccess] @userId, @taskId", new SqlParameter("userId", userId), new SqlParameter("@taskId", taskId));
        }

        public Task SetUserTaskAsFail(int userId, int taskId)
        {
            return _context.Database.ExecuteSqlRawAsync("exec [dbo].[SetUserTaskAsFail] @userId, @taskId", new SqlParameter("userId", userId), new SqlParameter("@taskId", taskId));
        }
    }
}
