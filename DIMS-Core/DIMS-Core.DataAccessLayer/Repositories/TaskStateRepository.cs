using System.Collections.Generic;
using DIMS_Core.Common.Enums;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Task = System.Threading.Tasks.Task;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Interfaces.ExternRepositories;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskStateRepository : Repository<TaskState>, ITaskStateRepository
    {
        private static readonly Dictionary<StateType, string> _stateTypeDictionary = new()
                                                                                     {
                                                                                         {
                                                                                             StateType.Active, "Active"
                                                                                         },
                                                                                         {
                                                                                             StateType.Success, "Success"
                                                                                         },
                                                                                         {
                                                                                             StateType.Fail, "Fail"
                                                                                         }
                                                                                     };
        public TaskState ActiveState => GetAll().Single(q => q.StateName == _stateTypeDictionary[StateType.Active]);
        
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
