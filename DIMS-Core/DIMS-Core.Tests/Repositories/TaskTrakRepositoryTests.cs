using DIMS_Core.Common.Exceptions;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DIMS_Core.Tests.Repositories
{
    public class TaskTrakRepositoryTests : IDisposable
    {
        private readonly TaskTrackRepositoryFixture _fixture;
        public TaskTrakRepositoryTests()
        {
            _fixture = new TaskTrackRepositoryFixture();
        }

        [Fact]
        // Note: GetAll will work always in our case. It can be thrown into EF Core.
        // But it is implementation details of EF Core so we mustn't test these cases.
        public async Task GetAll_OK()
        {
            // Act
            var result = await _fixture.Repository
                                       .GetAll()
                                       .ToArrayAsync();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1, result.Length);
        }

        [Fact]
        public async Task GetById_OK()
        {
            // Act
            var result = await _fixture.Repository.GetById(_fixture.TaskTrackId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.TaskTrackId, result.TaskTrackId);
            Assert.Equal("Test Note", result.TrackNote);
            Assert.Equal(1, result.UserTaskId);
        }

        [Fact]
        public async Task GetById_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act, Assert
            await Assert.ThrowsAsync<InvalidArgumentException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public async Task GetById_NotExistTask_Fail()
        {
            // Arrange
            const int id = int.MaxValue;

            // Act, Assert
            await Assert.ThrowsAsync<ObjectNotFoundException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public async Task Create_OK()
        {
            // Arrange
            var entity = new DataAccessLayer.Models.TaskTrack
            {
                TrackDate = DateTime.Now,
                TrackNote = "Test Note 1",
                UserTaskId = 2
            };

            // Act
            var result = await _fixture.Repository.Create(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(default, result.TaskTrackId);
            Assert.Equal(entity.TrackDate, result.TrackDate);
            Assert.Equal(entity.TrackNote, result.TrackNote);
            Assert.Equal(entity.UserTaskId, result.UserTaskId);
        }

        [Fact]
        public async Task Create_EmptyEntity_Fail()
        {
            // Arrange Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Create(null));
        }

        [Fact]
        public async Task Update_OK()
        {
            // Arrange
            var entity = new DataAccessLayer.Models.TaskTrack
            {
                TaskTrackId = _fixture.TaskTrackId,
                TrackDate = DateTime.Now,
                TrackNote = "Test Note 2",
                UserTaskId = 3
            };

            // Act
            var result = _fixture.Repository.Update(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(default, result.TaskTrackId);
            Assert.Equal(entity.TrackDate, result.TrackDate);
            Assert.Equal(entity.TrackNote, result.TrackNote);
            Assert.Equal(entity.UserTaskId, result.UserTaskId);
        }

        [Fact]
        public void Update_EmptyEntity_Fail()
        {
            // Arrange Act, Assert
            Assert.Throws<ObjectNotFoundException>(() => _fixture.Repository.Update(null));
        }

        [Fact]
        public async Task Delete_OK()
        {
            // Act
            await _fixture.Repository.Delete(_fixture.TaskTrackId);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            var deletedEntity = await _fixture.Context.Tasks.FindAsync(_fixture.TaskTrackId);
            Assert.Null(deletedEntity);
        }

        [Fact]
        public async Task Delete_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act, Assert
            await Assert.ThrowsAsync<ObjectNotFoundException>(() => _fixture.Repository.Delete(id));
        }

        public void Dispose()
        {
            _fixture?.Dispose();
        }
    }
}
