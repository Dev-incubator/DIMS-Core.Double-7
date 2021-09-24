using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class TaskRepositoryFixture : RepositoryFixture<TaskRepository>
    {
        public int TaskId { get; private set; }

        public override TaskRepository Repository => new(Context);

        protected override void InitDatabase()
        {
            var entity = Context.Tasks.Add(new DataAccessLayer.Models.Task
                                                      {
                                                          Name = "Test Name",
                                                          Description = "Test Description",
                                                          StartDate = new DateTime(2021, 06, 03, 08, 44, 50),
                                                          DeadlineDate = new DateTime(2021, 09, 25, 11, 47, 48)
                                                      });
            TaskId = entity.Entity.TaskId;
            Context.SaveChanges();
            entity.State = EntityState.Detached;
        }
    }
}