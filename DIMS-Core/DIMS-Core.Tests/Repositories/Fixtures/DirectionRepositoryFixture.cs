using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class DirectionRepositoryFixture : IDisposable
    {
        public DirectionRepositoryFixture()
        {
            Context = CreateContext();
            Repository = new DirectionRepository(Context);

            InitDatabase();
        }

        public DimsCoreContext Context { get; }

        public IRepository<Direction> Repository { get; }

        public int DirectionId { get; private set; }

        public void Dispose()
        {
            Context.Dispose();
        }

        private void InitDatabase()
        {
            DirectionId = Context.Directions.Add(new Direction
                                                 {
                                                     Name = "Test Direction",
                                                     Description = "Test Description"
                                                 }).Entity.DirectionId;

            Context.SaveChanges();
        }

        private static DimsCoreContext CreateContext()
        {
            var options = GetOptions();

            return new DimsCoreContext(options);
        }

        private static DbContextOptions<DimsCoreContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<DimsCoreContext>().UseInMemoryDatabase(GetInMemoryDbName());

            return builder.Options;
        }

        private static string GetInMemoryDbName()
        {
            return $"InMemory_{Guid.NewGuid()}";
        }
    }
}