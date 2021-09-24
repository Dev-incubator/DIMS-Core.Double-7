using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures.Base
{
    public abstract class ViewRepositoryFixture<TRepository> : IDisposable, IAsyncDisposable
    {
        protected ViewRepositoryFixture()
        {
            Context = ContextCreator.CreateViewContext();
        }
        public DimsCoreContext Context { get; }

        public abstract TRepository Repository { get; }

        public void Dispose() => Context.Dispose();
        
        public ValueTask DisposeAsync() => Context.DisposeAsync();
    }
}