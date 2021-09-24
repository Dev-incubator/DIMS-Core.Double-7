using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class TaskTrackRepositoryFixture : RepositoryFixture<TaskTrackRepository>
    {
        public int TaskTrackId { get; set; }
        protected override TaskTrackRepository CreateRepository => new(Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.TaskTracks.AddAsync(
                new DataAccessLayer.Models.TaskTrack
                {
                    TrackDate = DateTime.Now,
                    TrackNote = "Test Note",
                    UserTaskId = 1
                });
            TaskTrackId = entity.Entity.TaskTrackId;
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }
    }
}
