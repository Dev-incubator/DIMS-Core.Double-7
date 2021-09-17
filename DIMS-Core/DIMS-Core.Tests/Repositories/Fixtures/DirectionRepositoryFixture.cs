﻿using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class DirectionRepositoryFixture : BaseRepositoryFixture<DirectionRepository>, IDisposable
    {
        public int DirectionId { get; private set; }

        protected sealed override DirectionRepository CreateRepository() => new (Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.Directions.AddAsync(
                                             new Direction
                                             {
                                                 Name = "Test Direction",
                                                 Description = "Test Description"
                                             });
            DirectionId = entity.Entity.DirectionId;
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }
        
        public new void Dispose() => Context.Dispose();
    }
}