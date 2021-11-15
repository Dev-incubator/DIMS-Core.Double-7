using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskEntity = DIMS_Core.DataAccessLayer.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskRepository : Repository<TaskEntity>
    {
        private readonly DatabaseFacade _database;
        
        public TaskRepository(DimsCoreContext context) : base(context)
        {
            _database = GetDb();
        }

        public override async Task<TaskEntity> GetById(int id)
        {
            RepositoryException.IsIdValid(id);
            
            var foundEntity = (await Set.Include(task => task.UserTasks)
                                        .ThenInclude(ut => ut.User)
                                        .ToListAsync())
                                .FirstOrDefault(el => el.TaskId == id);

            RepositoryException.IsEntityExists(foundEntity, typeof(TaskEntity).FullName);

            return foundEntity;
        }

        public override async Task Delete(int taskId)
        {
            var deletedEntity = await Set.FindAsync(taskId);
            
            RepositoryException.IsEntityExists(deletedEntity, typeof(TaskEntity).FullName);
            
            await _database.ExecuteSqlRawAsync("DeleteTask @taskId", new SqlParameter("@taskId", taskId));
        }
    }
}