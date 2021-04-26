using Gosei.SimpleTaskApp.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Web.Models.Employees
{
    public class IndexViewModel
    {
        public IReadOnlyList<EmployeeListDto> Employees { get; }
        public IndexViewModel(IReadOnlyList<EmployeeListDto> employees)
        {
            Employees = employees;
        }
    }
}
