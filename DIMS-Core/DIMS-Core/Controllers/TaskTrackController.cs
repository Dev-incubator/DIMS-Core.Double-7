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
    [Route("task-tracks")]
    public class TaskTrackController : BaseController
    {
        private readonly ITaskTrackService _taskTrackService;
        public TaskTrackController(IMapper mapper, ILogger<TaskTrackController> logger,
                                   ITaskTrackService taskTrackService) : base(mapper, logger)
        {
            _taskTrackService = taskTrackService;
        }
        
        public async Task<IActionResult> Index()
        {
            var models = await _taskTrackService.GetAll();
            var viewModels = Mapper.Map<IEnumerable<TaskTrackViewModel>>(models);

            return View(viewModels);
        }
        
        [HttpGet("create")]
        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost("create")]
        public IActionResult Create(TaskTrackViewModel taskTrackViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskTrackViewModel);
            }

            var taskTrackModel = Mapper.Map<TaskTrackModel>(taskTrackViewModel);

            var task = _taskTrackService.Create(taskTrackModel);
            
            if (task != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return PartialView(taskTrackViewModel);
        }

        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var taskTrackModel = await _taskTrackService.GetById(id);

            var taskTrackViewModel = Mapper.Map<TaskTrackViewModel>(taskTrackModel);

            return PartialView(taskTrackViewModel);
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskTrackViewModel taskTrackViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskTrackViewModel);
            }

            var taskTrackModel = Mapper.Map<TaskTrackModel>(taskTrackViewModel);

            var task = await _taskTrackService.Update(taskTrackModel);

            if (task is null)
            {
                return View(taskTrackViewModel);
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
            await _taskTrackService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}