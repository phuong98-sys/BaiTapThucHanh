using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Controllers;
using Test1.Tasks;
using Test1.Tasks.Dto;
using Test1.Web.Models.Tasks;

namespace Test1.Web.Controllers
{
    public class TasksController : Test1ControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items);
            return View(model);
        }
    }
}
