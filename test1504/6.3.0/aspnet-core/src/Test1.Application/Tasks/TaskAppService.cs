using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1.Tasks.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
namespace Test1.Tasks
{
    public class TaskAppService : Test1AppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;// used to abstract database operations
        
        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input) // return IQueryable
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
