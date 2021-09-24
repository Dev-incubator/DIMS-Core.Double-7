using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class TaskStateRepositoryFixture : RepositoryFixture<TaskStateRepository>
    {
        public int StateId { get; set; }
        protected override TaskStateRepository CreateRepository => new(Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.TaskStates.AddAsync(
                new DataAccessLayer.Models.TaskState
                {
                    StateName = "Test State"
                });

            StateId = entity.Entity.StateId;
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }
    }
}
