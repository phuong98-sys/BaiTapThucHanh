using System.Collections.Generic;
using System.Linq;

using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Gosei.SimpleTaskApp;
using Microsoft.EntityFrameworkCore;
using Gosei.SimpleTaskApp.Tasks.Dto;
using Gosei.SimpleTaskApp.Tasks;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Tasks
{
    public class TaskAppService : SimpleTaskAppAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Gosei.SimpleTaskApp.Tasks.Task> _taskRepository;

        public TaskAppService(IRepository<Gosei.SimpleTaskApp.Tasks.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }
    }
}