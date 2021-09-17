using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VUserTrackRepositoryFixture : BaseRepositoryFixture<VUserTrackRepository>, IDisposable
    {
        protected override VUserTrackRepository CreateRepository() => new(Context);

        protected override async Task InitDatabase()
        {
            var entity = await Context.VUserTracks.AddAsync(new VUserTrack
                                              {
                                                  UserId = 1,
                                                  TaskId = 1,
                                                  TaskTrackId = 1,
                                                  TaskName = "Name",
                                                  TrackNote = "Note",
                                                  TrackDate = new DateTime(2021, 02, 03, 08, 20, 50)
                                              });
            
            await Context.SaveChangesAsync();
            entity.State = EntityState.Detached;
        }

        public void Dispose() => Context.Dispose();

    }
}