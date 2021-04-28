using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Gosei.SimpleTaskApp.Employees.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Employees
{
    public class EmployeeAppService:SimpleTaskAppAppServiceBase,IEmployeeAppService
    {
        private readonly IRepository<Employee> _employeeRepository;
   
        public EmployeeAppService(IRepository<Employee> employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ListResultDto<EmployeeListDto>> GetAll()
        {
          var employees = await _employeeRepository.GetAll().ToListAsync();

            return new ListResultDto<EmployeeListDto>(
                ObjectMapper.Map<List<EmployeeListDto>>(employees));
        }
    }
}
