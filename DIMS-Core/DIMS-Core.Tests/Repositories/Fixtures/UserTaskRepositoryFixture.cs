using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class UserTaskRepositoryFixture : RepositoryFixture<UserTaskRepository>
    {
        public int UserTaskId { get; set; }
        protected override UserTaskRepository CreateRepository => new(Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.UserTasks.AddAsync(
                new DataAccessLayer.Models.UserTask
                {
                    StateId = 1,
                    TaskId = 1,
                    UserId = 1
                });

            UserTaskId = entity.Entity.UserTaskId;
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }
    }
}
