using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAngular.Tasks.DTO;

namespace TestAngular.Tasks
{
    public interface ITaskAppService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTaskInput input);
        Task Create(CreateTaskInput input);
      
        }
}
