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
            var stateIds = Enumerable.Repeat(_stateRepository
                                             .GetAll()
                                             .First(s => s.StateName == _stateTypeDictionary[StateType.Active])
                                             .StateId, 
                                             model.UserTasks.Count);
            
            model.UserTasks = model.UserTasks
                                   .Select((ut, i) => 
                                           { 
                                               ut.StateId = stateIds.ElementAt(i); 
                                               return ut; 
                                           }).ToArray();
            
            
            //  model.UserTasks
            return await base.Create(model);
        }
        public override async Task<TaskModel> Update(TaskModel model)
        {
            var stateIds = Enumerable.Repeat(_stateRepository
                                             .GetAll()
                                             .First(s => s.StateName == _stateTypeDictionary[StateType.Active])
                                             .StateId, 
                                             model.UserTasks.Count);
            
            model.UserTasks = model.UserTasks
                                   .Select((ut, i) => 
                                           { 
                                               ut.StateId = stateIds.ElementAt(i); 
                                               return ut; 
                                           }).ToArray();
            
            
            //  model.UserTasks
            return await base.Update(model);
        }
    }
}