using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;
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

        public TaskController(IMapper mapper, ILogger<TaskController> logger,
                              ITaskService taskService,
                              IVTaskService vTaskService) : base(mapper, logger)
        {
            _taskService = taskService;
            _vTaskService = vTaskService;
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

            return View(viewModel);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(TaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskViewModel);
            }

            var taskModel = Mapper.Map<TaskModel>(taskViewModel);

            var task = _taskService.Create(taskModel);
            
            if (task != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(taskViewModel);
        }
        
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var taskModel = await _taskService.GetById(id);

            var taskViewModel = Mapper.Map<TaskViewModel>(taskModel);

            return View(taskViewModel);
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskViewModel);
            }

            var taskModel = Mapper.Map<TaskModel>(taskViewModel);

            var task = await _taskService.Update(taskModel);

            if (task != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(taskViewModel);
        }
        
        [HttpGet("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
        
        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}