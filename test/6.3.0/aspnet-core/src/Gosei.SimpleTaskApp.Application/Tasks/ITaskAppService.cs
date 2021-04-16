using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Gosei.SimpleTaskApp.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
        System.Threading.Tasks.Task Create(CreateTaskInput input);
    }
}
