using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("tasks")]
    public class TaskController : BaseController
    {
        
        private readonly ITaskService _taskService;
        private readonly IVTaskService _vTaskService;
        private readonly IUserProfileService _userProfileService;

        public TaskController(IMapper mapper,
                              ILogger<TaskController> logger,
                              ITaskService taskService,
                              IVTaskService vTaskService,
                              IUserProfileService userProfileService) : base(mapper, logger)
        {
            _taskService = taskService;
            _vTaskService = vTaskService;
            _userProfileService = userProfileService;
        }

        public async Task<IActionResult> Index()
        {
            var readOnlyModels = await _vTaskService.GetAll();
            var viewModels = Mapper.Map<IEnumerable<VTaskViewModel>>(readOnlyModels);

            return View(viewModels);
        }

        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _taskService.GetById(id);
            
            var viewModel = Mapper.Map<TaskViewModel>(model);

            return PartialView(viewModel);
        }
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            await SetUsersToViewBag();

            return PartialView();
        }
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(taskViewModel);
            }
            
            var taskModel = Mapper.Map<TaskModel>(taskViewModel);

            foreach (var userId in taskViewModel.UserIds)
            {
                taskModel.UserTasks.Add(new UserTaskModel { UserId = userId } );
            }
            
            var task = await _taskService.Create(taskModel);
            
            if (task == null)
            {
                return PartialView(taskViewModel);
            }

            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var taskModel = await _taskService.GetById(id);
            
            if (taskModel != null)
            {
                var taskViewModel = Mapper.Map<TaskViewModel>(taskModel);

                taskViewModel.UserIds = taskViewModel.UserTasks
                                                     .Select(ut => ut.UserId)
                                                     .Distinct()
                                                     .ToArray();
                
                await SetUsersToViewBag(taskViewModel.UserIds);
                
                
                return PartialView(taskViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(taskViewModel);
            }

            var taskModel = Mapper.Map<TaskModel>(taskViewModel);
            
            foreach (var userId in taskViewModel.UserIds)
            {
                taskModel.UserTasks.Add(new UserTaskModel { UserId = userId, TaskId = taskModel.TaskId } );
            }
            
            var task = await _taskService.Update(taskModel);

            if (task == null)
            {
                return PartialView(taskViewModel);
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            return PartialView();
        }
        
        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private Task<List<UserProfileModel>> GetUsers() => _userProfileService.GetAll();
        
        [NonAction]
        private async Task SetUsersToViewBag(ICollection<int> userIds = null)
        {
            var userProfiles = Mapper.Map<List<UserProfileViewModel>>( await GetUsers() );
            
            var usersSelectList = userIds is null 
                ? new SelectList(userProfiles, "UserId", "FullName")
                : new SelectList(userProfiles, "UserId", "FullName", userIds);
            
            ViewBag.Users = usersSelectList;
        }
    }
}