using Abp.Application.Services.Dto;
using Gosei.SimpleTaskApp.Controllers;
using Gosei.SimpleTaskApp.Persons;
using Gosei.SimpleTaskApp.Tasks;
using Gosei.SimpleTaskApp.Tasks.Dto;
using Gosei.SimpleTaskApp.Web.Models.People;
using Gosei.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ILookupAppService _lookupAppService;


        public TasksController(ITaskAppService taskAppService, ILookupAppService lookupAppService)
        {
            _taskAppService = taskAppService;
            _lookupAppService = lookupAppService;
        }

        public async Task<ActionResult> Index(GetAllTasksInput input, int id)
        {
           
            var output2 = _taskAppService.GetTask(id);
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items, output2)
            {
                SelectedTaskState = input.State
            };
            return View(model);
        }
        //public async Task<ActionResult> Index(GetAllTasksInput input)
        //{
        //    //var output2 = _taskAppService.GetTask(input2);
        //    var output = await _taskAppService.GetAll(input);


        //    var model = new IndexViewModel(output.Items)
        //    {
        //        SelectedTaskState = input.State
        //    };
        //    return View(model);
        //}
        public async Task<ActionResult> Create()
        {
            var peopleSelectListItems = (await _lookupAppService.GetPeopleComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View(new CreateTaskViewModel(peopleSelectListItems));
        }
    }
}
