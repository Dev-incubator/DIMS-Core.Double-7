using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class DirectionRepositoryFixture : RepositoryFixture<DirectionRepository>
    {
        public int DirectionId { get; private set; }

        protected override void InitDatabase()
        {
            var entity = Context.Directions.Add(
                                             new Direction
                                             {
                                                 Name = "Test Name",
                                                 Description = "Test Description"
                                             });
            DirectionId = entity.Entity.DirectionId;
            Context.SaveChanges();
            entity.State = EntityState.Detached;
        }

        protected override DirectionRepository CreateRepository() => new (Context);
    }
}