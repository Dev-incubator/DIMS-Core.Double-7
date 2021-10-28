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
        private readonly IRepository<TaskState>  _stateRepository;
        private readonly Dictionary<StateType, string> _stateTypeDictionary = new () 
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
        public TaskService(IRepository<TaskState> stateRepository, 
                           IRepository<Task> repository, 
                           IMapper mapper)
            : base(repository, mapper)
        {
            _stateRepository = stateRepository;
        }
        
        public override async Task<TaskModel> Create(TaskModel model)
        {
            var stateId = _stateRepository.GetAll()
                                          .Where(q => q.StateName == _stateTypeDictionary[StateType.Active])
                                          .Select(q => q.StateId)
                                          .SingleOrDefault();
            
            model.UserTasks = model.UserTasks
                                   .Select((ut, _) => 
                                           { 
                                               ut.StateId = stateId;
                                               return ut; 
                                           }).ToArray();
            
            
            //  model.UserTasks
            return await base.Create(model);
        }
        public override async Task<TaskModel> Update(TaskModel model)
        {
            var stateId = _stateRepository.GetAll()
                                           .Where(q => q.StateName == _stateTypeDictionary[StateType.Active])
                                           .Select(q => q.StateId)
                                           .SingleOrDefault();
            // TODO task part
            // take model.UserTasks repo.getById
            // merge my userTasks from DB with Frontend
            // using operation Except
            // 1. two variables 
            // existing - first variable array userIds
            // newUserTasks - second variable array userIds
            // 2. created - newUserTasks.Except(existing)
            // 3. will not updating - newUserTasks.Intersect(existing)
            // 4. 2 foreach
            // -created-
            // init empty list
            // take taskId, UserId, StateId
            // -updating-
            // entity.UserTasks.Where(UserId == ut.UserId).Single() Map TO UserTaskModel
            // add to modelUserTasks

            model.UserTasks = model.UserTasks
                                   .Select((ut, _) => 
                                           { 
                                               ut.StateId = stateId;
                                               return ut; 
                                           }).ToArray();
            
            
            return await base.Update(model);
        }
    }
}