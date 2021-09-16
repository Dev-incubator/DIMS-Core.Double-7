using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public abstract class BaseRepositoryFixture<TRepository> : IDisposable, IAsyncDisposable
    {
        private TRepository _repository;

        protected BaseRepositoryFixture()
        {
            Context = ContextCreator.CreateContext();
            InitDatabase();
        }
        public DimsCoreContext Context { get; }

        public TRepository Repository => _repository ??= CreateRepository();
        
        protected abstract TRepository CreateRepository();
        protected abstract Task InitDatabase();

        public void Dispose() => Context.Dispose();
        
        public ValueTask DisposeAsync() => Context.DisposeAsync();
    }
}