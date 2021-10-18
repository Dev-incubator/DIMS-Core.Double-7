using System;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.Common.Exceptions;
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
        public override async Task<ModelTask> GetById(int id)
        {
            RepositoryException.IsIdValid(id);
            
            var foundEntity = (await Set.Include(el => el.UserTasks)
                                            .ThenInclude(ut => ut.Task)
                                        .Include(ut => ut.UserTasks)
                                            .ThenInclude(ut => ut.User)
                                        .Include(ut => ut.UserTasks)
                                            .ThenInclude(ut => ut.State)
                                        .ToListAsync())
                .FirstOrDefault(el => el.TaskId == id);

            RepositoryException.IsEntityExists(foundEntity, typeof(ModelTask).FullName);

            return foundEntity;
        }
        public override async Task<ModelTask> Create(ModelTask entity)
        {
            var createEntity = (await Set.Include(el => el.UserTasks)
                                            .ThenInclude(ut => ut.Task)
                                        .Include(ut => ut.UserTasks)
                                            .ThenInclude(ut => ut.User)
                                        .Include(ut => ut.UserTasks)
                                            .ThenInclude(ut => ut.State)
                                        .ToListAsync())
                .FirstOrDefault(el => el.Equals(entity));
            
            var addedEntity = await Set.AddAsync(createEntity);
            
            return addedEntity.Entity;
        }

        public override ModelTask Update(ModelTask entity)
        {
            var updateEntity = Set.Include(el => el.UserTasks)
                                    .ThenInclude(ut => ut.Task)
                                  .Include(ut => ut.UserTasks)
                                     .ThenInclude(ut => ut.User)
                                  .Include(ut => ut.UserTasks)
                                     .ThenInclude(ut => ut.State)
                                  .FirstOrDefault(el => el.Equals(entity));
            
            RepositoryException.IsEntityExists(updateEntity, typeof(ModelTask).FullName);
            
            Set.Attach(updateEntity).State = EntityState.Modified;
            
            return updateEntity;
        }

        public override async Task Delete(int taskId)
        {
            var deletedEntity = await Set.FindAsync(taskId);
            
            RepositoryException.IsEntityExists(deletedEntity, typeof(ModelTask).FullName);
            
            await _database.ExecuteSqlRawAsync("DeleteTask @taskId", new SqlParameter("@taskId", taskId));
        }
    }
}