using DIMS_Core.DataAccessLayer.Models;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces.ExternRepositories
{
    public interface ITaskStateRepository : IRepository<TaskState>
    {
        public TaskState ActiveState { get; }
        
        Task SetUserTaskAsSuccess(int userId, int taskId);
        
        Task SetUserTaskAsFail(int userId, int taskId);
    }
}