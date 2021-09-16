using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class DirectionRepositoryFixture : BaseRepositoryFixture<DirectionRepository>, IDisposable
    {
        public int DirectionId { get; private set; }

        public new void Dispose() => Context.Dispose();

        protected sealed override DirectionRepository CreateRepository() => new (Context);

        protected override async Task InitDatabase()
        {
            DirectionId = Context.Directions.Add(
                                             new Direction
                                             {
                                                 Name = "Test Direction",
                                                 Description = "Test Description"
                                             })
                                            .Entity.DirectionId;

            await Context.SaveChangesAsync();
        }
    }
}