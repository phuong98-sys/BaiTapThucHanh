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
using Abp.UI;
using System.Threading;

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
                .Include(t => t.AssignedPerson) //truy van them ca bang nay de hien thi, tu dong copy vao DTO by AutoMapper
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }

        //public TaskListDto GetTask(int id)
        //{
        //    var task = _taskRepository.FirstOrDefault(x => x.Id == id);
        //    var output = ObjectMapper.Map<TaskListDto>(task);
        //    return output;
        //}
        public TaskListDto GetTask(GetTaskInput input)
        {
            var task = _taskRepository.FirstOrDefault(x => x.Id == input.Id);
            var output = ObjectMapper.Map<TaskListDto>(task);
            return output;
        }
        public void Delete(int id)
        {
            var task = _taskRepository.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _taskRepository.Delete(task);
            }
        }
        public async System.Threading.Tasks.Task Update(UpdateTaskInput input)
        {
            //C1:
            var task = await _taskRepository.FirstOrDefaultAsync(t => t.Id == input.Id);

            ObjectMapper.Map(input, task);

            //var task = GetTask(input.Id);
            //C2:
            //var output = ObjectMapper.Map<Task>(input); 
            //await _taskRepository.UpdateAsync(output);
        }
        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _taskRepository.InsertAsync(task); // ko trả ve thi thuong dung cach nay
        }
    }
}