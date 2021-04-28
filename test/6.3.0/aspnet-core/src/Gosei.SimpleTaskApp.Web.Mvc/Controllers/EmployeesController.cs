
using Gosei.SimpleTaskApp.Controllers;
using Gosei.SimpleTaskApp.Employees;
using Gosei.SimpleTaskApp.Web.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Web.Controllers
{
    public class EmployeesController : SimpleTaskAppControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;
        public EmployeesController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        public async Task<ActionResult> Index()
        {
            var employees = await _employeeAppService.GetAll();
            var model = new IndexViewModel(employees.Items);
            return View(model);
        }
    }
}
