using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Common.Enums;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Task = DIMS_Core.DataAccessLayer.Models.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class TaskService : Service<TaskModel, Task, IRepository<Task>>, ITaskService
    {
        private static readonly Dictionary<StateType, string> _stateTypeDictionary = new()
                                                                                     {
                                                                                         {
                                                                                             StateType.Active, "Active"
                                                                                         },
                                                                                         {
                                                                                             StateType.Success, "Success"
                                                                                         },
                                                                                         {
                                                                                             StateType.Fail, "Fail"
                                                                                         }
                                                                                     };

        private readonly IRepository<TaskState> _stateRepository;
        private readonly IRepository<UserTask> _userTaskRepository;

        public TaskService(IRepository<TaskState> stateRepository,
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
            var defaultStateId = _stateRepository.GetAll()
                                          .Where(q => q.StateName == _stateTypeDictionary[StateType.Active])
                                          .Select(q => q.StateId)
                                          .SingleOrDefault();

            model.UserTasks = model.UserTasks
                                   .Select((ut, _) =>
                                           {
                                               ut.StateId = defaultStateId;
                                               return ut;
                                           })
                                   .ToArray();


            return await base.Create(model);
        }

        // Done TODO task update
        // take model.UserTasks repo.getById
        // merge my userTasks from DB with Frontend
        // 1. two variables 
        // existing - first variable array userIds
        // newUserTasks - second variable array userIds
        // 2. created - newUserTasks.Except(existing)
        // 3. will not updating - newUserTasks.Intersect(existing)
        // 4. deleted - existing.Except(newUserTasks)
        // 5. 3 foreach
        // -created-
        // init empty list
        // take taskId, UserId, StateId
        // -not updating-
        // entity.UserTasks.Where(UserId == ut.UserId).Single()
        // -deleted-
        // remove 
        // add to modelUserTasks
        public override async Task<TaskModel> Update(TaskModel model)
        {

            var defaultStateId = _stateRepository.GetAll()
                                                 .Where(q => q.StateName == _stateTypeDictionary[StateType.Active])
                                                 .Select(q => q.StateId)
                                                 .SingleOrDefault();
            
            model.UserTasks = model.UserTasks
                                   .Select((ut, _) =>
                                           {
                                               ut.StateId = defaultStateId;
                                               return ut;
                                           })
                                   .ToArray();
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