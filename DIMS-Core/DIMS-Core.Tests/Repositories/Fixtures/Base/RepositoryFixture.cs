﻿using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures.Base
{
    public abstract class RepositoryFixture<TRepository> : IDisposable, IAsyncDisposable
    {
        private TRepository _repository;
        private readonly ContextCreator _creator = new ();
        
        private static readonly DbContextOptions<DimsCoreContext> _options =
            new DbContextOptionsBuilder<DimsCoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

        protected RepositoryFixture()
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