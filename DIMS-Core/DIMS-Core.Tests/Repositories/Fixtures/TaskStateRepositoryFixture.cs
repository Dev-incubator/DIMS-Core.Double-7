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
        protected override TaskStateRepository CreateRepository() => new(Context);

        protected override void InitDatabase()
        {
            var entity = Context.TaskStates.Add(
                new DataAccessLayer.Models.TaskState
                {
                    StateName = "Test State"
                });

            StateId = entity.Entity.StateId;
            Context.SaveChanges();
            entity.State = EntityState.Detached;
        }
    }
}
