using Gosei.SimpleTaskApp.Controllers;
using Gosei.SimpleTaskApp.Persons;
using Gosei.SimpleTaskApp.Persons.Dto;
using Gosei.SimpleTaskApp.Web.Models.People;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Web.Controllers
{
    public class PeopleController : SimpleTaskAppControllerBase
    {
        private readonly IPersonAppService _personAppService;
        public PeopleController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        public async Task<ActionResult> Index()
        {
            var people = await _personAppService.GetAll();
            var output = new PersonViewModel(people);
            return View(output);
        }
       public async Task<ActionResult> Create()
        {
            return View();
        }
    }
}
