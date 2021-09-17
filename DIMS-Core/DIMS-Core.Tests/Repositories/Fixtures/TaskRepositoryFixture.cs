using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class TaskRepositoryFixture : BaseRepositoryFixture<TaskRepository>, IDisposable
    {
        public int TaskId { get; private set; }

        public new void Dispose()
        {
            Context.Dispose();
        }

        protected override TaskRepository CreateRepository() => new(Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.Tasks.AddAsync(new DataAccessLayer.Models.Task
                                                      {
                                                          Name = "Test Name",
                                                          Description = "Test Description",
                                                          StartDate = new DateTime(2021, 06, 03, 08, 44, 50),
                                                          DeadlineDate = new DateTime(2021, 09, 25, 11, 47, 48)
                                                      });
            TaskId = entity.Entity.TaskId;
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }
    }
}