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
        private readonly AutoMapper.IMapper _mapper;
        public EmployeeAppService(IRepository<Employee> employeeRepository, AutoMapper.IMapper mapper) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeListDto>> GetAll()
        {
            var employees = await _employeeRepository.GetAll().ToListAsync();
          var emp= new List<EmployeeListDto>(
                _mapper.Map<List<EmployeeListDto>>(employees)
                );
            return emp;
        }
    }
}
