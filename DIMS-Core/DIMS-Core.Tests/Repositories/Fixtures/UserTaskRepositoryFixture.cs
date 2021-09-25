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
        protected override UserTaskRepository CreateRepository() => new(Context);

        protected override void InitDatabase()
        {
            var entity = Context.UserTasks.Add(
                new DataAccessLayer.Models.UserTask
                {
                    StateId = 1,
                    TaskId = 1,
                    UserId = 1
                });

            UserTaskId = entity.Entity.UserTaskId;
            Context.SaveChanges();
            entity.State = EntityState.Detached;
        }
    }
}
