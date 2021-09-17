using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VTaskRepositoryFixture : BaseRepositoryFixture<VTaskRepository>, IDisposable
    {
        protected override VTaskRepository CreateRepository() => new (Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.Tasks.AddAsync(new DataAccessLayer.Models.Task
                                          {
                                              Name = "Test Name",
                                              Description = "Test Description",
                                              StartDate = new DateTime(2021, 06, 03, 08, 44, 50),
                                              DeadlineDate = new DateTime(2021, 09, 25, 11, 47, 48)
                                          });
            
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }

        public void Dispose() => Context.Dispose();
    }
}