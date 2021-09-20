using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures.Base
{
    public abstract class ViewRepositoryFixture<TRepository> : IDisposable, IAsyncDisposable
    {
        private TRepository _repository;
        private readonly ContextCreator _creator = new ();

        protected ViewRepositoryFixture()
        {
            Context = ContextCreator.CreateViewContext();
        }
        public DimsCoreContext Context { get; }

        public TRepository Repository => _repository ??= CreateRepository();
        
        protected abstract TRepository CreateRepository();

        public void Dispose() => Context.Dispose();
        
        public ValueTask DisposeAsync() => Context.DisposeAsync();
    }
}