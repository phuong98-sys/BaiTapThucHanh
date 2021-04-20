﻿using System.Collections.Generic;
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

        public TaskListDto GetTask(GetTaskInput input)
        {
            var task= _taskRepository.Get(int.Parse(input.Id.ToString()));
            var output = ObjectMapper.Map<TaskListDto>(task);
            return output;
        }
        public void Delete(DeleteTaskInput input)
        {
            var task = _taskRepository.FirstOrDefault(x => x.Id == input.Id);
            if (task == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _taskRepository.Delete(task);
            }
        }
        public async void Update(UpdateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _taskRepository.UpdateAsync(task);
        }
        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await _taskRepository.InsertAsync(task);
        }
    }
}