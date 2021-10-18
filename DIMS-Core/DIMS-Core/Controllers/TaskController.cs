using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("tasks")]
    public class TaskController : BaseController
    {
        
        private readonly ITaskService _taskService;
        private readonly IVTaskService _vTaskService;
        private readonly IUserTaskService _userTaskService;
        public TaskController(IMapper mapper,
                              ILogger<TaskController> logger,
                              ITaskService taskService,
                              IVTaskService vTaskService,
                              IUserTaskService userTaskService) : base(mapper, logger)
        {
            _taskService = taskService;
            _vTaskService = vTaskService;
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
        public IActionResult Create()
        {
            ViewBag.UserTasks = _userTaskService.GetAll();
            return PartialView();
        }
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskViewModel taskViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return PartialView(taskViewModel);
            }

            var taskModel = Mapper.Map<TaskModel>(taskViewModel);

            var task = _taskService.Create(taskModel);
            
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

            var taskViewModel = Mapper.Map<TaskViewModel>(taskModel);

            return PartialView(taskViewModel);
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

            if (task is null)
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

    }
}