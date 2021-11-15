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
        private readonly IVUserTrackService _vUserTrackService;
        public TaskTrackController(IMapper mapper, ILogger<TaskTrackController> logger,
                                   ITaskTrackService taskTrackService,
                                   IVUserTrackService vUserTrackService) : base(mapper, logger)
        {
            _taskTrackService = taskTrackService;
            _vUserTrackService = vUserTrackService;
        }
        
        public async Task<IActionResult> Index()
        {
            var models = await _vUserTrackService.GetAll();
            var viewModels = Mapper.Map<IEnumerable<VUserTrackViewModel>>(models);

            return View(viewModels);
        }
        
        [HttpGet("create")]
        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskTrackViewModel taskTrackViewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(taskTrackViewModel);
            }

            var taskTrackModel = Mapper.Map<TaskTrackModel>(taskTrackViewModel);

            var task = await _taskTrackService.Create(taskTrackModel);
            
            if (task is null)
            {
                return PartialView(taskTrackViewModel);
            }

            return RedirectToAction(nameof(Index));
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
                return PartialView(taskTrackViewModel);
            }

            var taskTrackModel = Mapper.Map<TaskTrackModel>(taskTrackViewModel);

            var task = await _taskTrackService.Update(taskTrackModel);

            if (task != null)
            {
                return PartialView(taskTrackViewModel);
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