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
        private readonly  IUserTaskService _userTaskService;

        public TaskController(IMapper mapper,
                              ILogger<TaskController> logger,
                              ITaskService taskService,
                              IVTaskService vTaskService,
                              IUserProfileService userProfileService,
                              IUserTaskService userTaskService) : base(mapper, logger)
        {
            _taskService = taskService;
            _vTaskService = vTaskService;
            _userProfileService = userProfileService;
            _userTaskService = userTaskService;
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
            await SetUsersToCreate();

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
            // added userTasks to taskModel
            var userTasks = (await _userTaskService.GetAll())
                .Where(u => taskViewModel.UserIds.Any(id => id == u.UserId));

            foreach (var userTask in userTasks)
            {
                taskModel.UserTasks.Add(userTask);   
            }
            // !added userTasks to taskModel
            var task = await _taskService.Create(taskModel);
            
            if (task != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return PartialView(taskViewModel);
        }
        
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var taskModel = await _taskService.GetById(id);
            
            if (taskModel != null)
            {
                SetUsersToUpdate(taskModel);
                
                var taskViewModel = Mapper.Map<TaskViewModel>(taskModel);

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

            var task = await _taskService.Update(taskModel);

            if (task != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return PartialView(taskViewModel);
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
        private async Task SetUsersToCreate()
        {
            var userProfileModels = Mapper.Map<List<UserProfileViewModel>>(await _userProfileService.GetAll());
            var users = new SelectList(userProfileModels, "UserId", "FullName");
            ViewBag.Users = users;
        }
        [NonAction]
        private void SetUsersToUpdate(TaskModel taskModel)
        {
            // added userTaskIds to taskModel
            var userTaskIds = taskModel.UserTasks
                                       .Select(ut => ut.UserTaskId)
                                       .ToArray();
            
            taskModel.UserTaskIds = new List<int>();
            foreach (var userTaskId in userTaskIds)
            {
                taskModel.UserTaskIds.Add(userTaskId);   
            }
            // !added userTaskIds to taskModel
            var taskViewModel = Mapper.Map<TaskViewModel>(taskModel);
            var users = new SelectList(taskModel.UserTasks, "UserId", "FullName", taskViewModel.UserIds);
            ViewBag.Users = users;
        }
    }
}