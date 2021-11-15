using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Common.Enums;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces.ExternRepositories;
using DIMS_Core.DataAccessLayer.Models;
using Task = DIMS_Core.DataAccessLayer.Models.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class TaskService : Service<TaskModel, Task, IRepository<Task>>, ITaskService
    {
        private readonly ITaskStateRepository _stateRepository;
        private readonly IRepository<UserTask> _userTaskRepository;

        public TaskService(ITaskStateRepository stateRepository,
                           IRepository<Task> repository,
                           IRepository<UserTask> userTaskRepository,
                           IMapper mapper)
            : base(repository, mapper)
        {
            _stateRepository = stateRepository;
            _userTaskRepository = userTaskRepository;
        }

        public override async Task<TaskModel> Create(TaskModel model)
        {
            var defaultStateId = _stateRepository.ActiveState.StateId;

            foreach (var userTask in model.UserTasks)
            {
                userTask.StateId = defaultStateId;
            }


            return await base.Create(model);
        }

        public override async Task<TaskModel> Update(TaskModel model)
        {
            var defaultStateId = _stateRepository.ActiveState.StateId;
            
            foreach (var userTask in model.UserTasks)
            {
                userTask.StateId = defaultStateId;
            }
            
            // frontend
            var userIdsFromFrontend = model.UserTasks
                                           .Select(ut => ut.UserId)
                                           .ToArray();

            // database
            var userIdsFromDb = _userTaskRepository.GetAll()
                                                   .Where(ut => ut.TaskId == model.TaskId)
                                                   .Select(ut => ut.UserId)
                                                   .Distinct()
                                                   .ToArray();

            var createdUserIds = userIdsFromFrontend.Except(userIdsFromDb);

            var userTasks = model.UserTasks.ToList();

            model.UserTasks = new List<UserTaskModel>();
            foreach (var createdUserId in createdUserIds)
            {
                model.UserTasks.Add(new UserTaskModel
                                    {
                                        UserId = createdUserId,
                                        TaskId = model.TaskId,
                                        StateId = defaultStateId
                                    });
            }

            var notUpdatedUserIds = userIdsFromDb.Intersect(userIdsFromFrontend);
            foreach (var notUpdatedUserId in notUpdatedUserIds)
            {
                var userTaskModelUpdated = userTasks.Single(ut => ut.UserId == notUpdatedUserId);
                model.UserTasks.Add(userTaskModelUpdated);
            }

            var deletedUserIds = userIdsFromDb.Except(userIdsFromFrontend);
            foreach (var deletedUserId in deletedUserIds)
            {
                model.UserTasks = model.UserTasks
                                       .Where(ut => ut.UserId != deletedUserId)
                                       .ToArray();
            }
            // !end of forwarding model.UserTasks

            var modelFromDb = await _repository.GetById(model.TaskId);

            var mappedEntity = _mapper.Map(model, modelFromDb); // merge map
            var updatedEntity = _repository.Update(mappedEntity);

            await _repository.Save();

            return _mapper.Map<TaskModel>(updatedEntity);
        }
    }
}