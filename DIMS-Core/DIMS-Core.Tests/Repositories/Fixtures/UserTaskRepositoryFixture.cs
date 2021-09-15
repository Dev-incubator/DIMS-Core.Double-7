using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class UserTaskRepositoryFixture : IDisposable
    {
        public UserTaskRepositoryFixture()
        {
            Context = CreateContext();
            Repository = new UserTaskRepository(Context);

            InitDatabase();
        }
        public DIMSCoreContext Context { get; }

        public IRepository<UserTask> Repository { get; }

        public int DirectionId { get; private set; }

        public void Dispose()
        {
            Context.Dispose();
        }

        private void InitDatabase()
        {
            DirectionId = Context.UserTasks.Add(new UserTask
            {
                
            }).Entity.UserTaskId;

            Context.SaveChanges();
        }

        private static DIMSCoreContext CreateContext()
        {
            var options = GetOptions();

            return new DIMSCoreContext(options);
        }

        private static DbContextOptions<DIMSCoreContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<DIMSCoreContext>().UseInMemoryDatabase(GetInMemoryDbName());

            return builder.Options;
        }

        private static string GetInMemoryDbName()
        {
            return $"InMemory_{Guid.NewGuid()}";
        }
    }
}
