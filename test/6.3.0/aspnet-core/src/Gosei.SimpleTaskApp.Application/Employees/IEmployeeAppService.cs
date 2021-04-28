using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Gosei.SimpleTaskApp.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
        public Task<ListResultDto<EmployeeListDto>> GetAll();



    }
}
