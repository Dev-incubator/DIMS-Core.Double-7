using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures.Base
{
    public abstract class RepositoryFixture<TRepository> : IDisposable, IAsyncDisposable
    {
        protected RepositoryFixture()
        {
            Context = ContextCreator.CreateContext();
            InitDatabase();
        }
        public DimsCoreContext Context { get; }

        public abstract TRepository Repository { get; }
        
        protected abstract void InitDatabase();

        public void Dispose() => Context.Dispose();
        
        public ValueTask DisposeAsync() => Context.DisposeAsync();
    }
}