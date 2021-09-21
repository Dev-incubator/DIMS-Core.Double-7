using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    /// <summary>
    ///     This class is unit of work pattern.
    ///     He is pretty popular in projects which have repository approach and using when you need to have access to many
    ///     repositories in one class under one context.
    ///     You can read about the pattern in Internet.
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DimsCoreContext _context;

        public UnitOfWork(DimsCoreContext context,
                          IRepository<UserProfile> userProfileRepository,
                          IRepository<Direction> directionRepository,
                          IRepository<TaskState> taskStateRepository,
                          IRepository<TaskTrack> taskTrackRepository,
                          IRepository<UserTask> userTaskRepository,
                          IReadOnlyRepository<VUserProfile> vUserProfileRepository,
                          IReadOnlyRepository<VUserTask> vUserTaskRepository)
        {
            _context = context;

            UserProfileRepository = userProfileRepository;
            DirectionRepository = directionRepository;
            TaskStateRepository = taskStateRepository;
            TaskTrackRepository = taskTrackRepository;
            UserTaskRepository = userTaskRepository;
            VUserTaskRepository = vUserTaskRepository;
            VUserProfileRepository = vUserProfileRepository;
        }

        public IRepository<UserProfile> UserProfileRepository { get; }

        public IRepository<Direction> DirectionRepository { get; }
        public IRepository<TaskState> TaskStateRepository { get; }
        public IRepository<TaskTrack> TaskTrackRepository { get; }
        public IRepository<UserTask> UserTaskRepository { get; }
        public IReadOnlyRepository<VUserTask> VUserTaskRepository { get; }
        public IReadOnlyRepository<VUserProfile> VUserProfileRepository { get; }

        /// <summary>
        ///     This method is not important here because each repository already has same method.
        ///     But remember you can use repositories separately from unit of work. So 'Save' method exists in UnitOfWork and
        ///     Repository.
        /// </summary>
        /// <returns></returns>
        public Task Save() => _context.SaveChangesAsync();

        public void Dispose() => _context?.Dispose();
    }
}