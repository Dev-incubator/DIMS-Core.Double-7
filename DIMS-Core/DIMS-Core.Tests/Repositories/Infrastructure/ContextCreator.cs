using System;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Infrastructure
{
    public static class ContextCreator
    {
        private static readonly DbContextOptions<DimsCoreContext> _options = 
            new DbContextOptionsBuilder<DimsCoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        public static DimsCoreContext CreateContext() => new (_options);
    }
}