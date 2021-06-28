using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAngular.Tasks.DTO;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using Acme.SimpleTaskApp.Tasks;
using System.Threading.Tasks;

namespace TestAngular.Tasks
{
    public class TaskAppService : TestAngularAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Acme.SimpleTaskApp.Tasks.Task> _taskRepository;
        public TaskAppService(IRepository<Acme.SimpleTaskApp.Tasks.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTaskInput input) {
            var tasks = await _taskRepository
                .GetAll()
                .WhereIf(input.State.HasValue, task => task.State == input.State.Value)
                .OrderByDescending(task => task.CreationTime)
                .ToListAsync();
            try
            {
                var dtos = ObjectMapper.Map<List<TaskListDto>>(tasks);

                return new ListResultDto<TaskListDto>(dtos);
            }
            catch(Exception e)
            {
                throw (e);
            }
     

            //return new ListResultDto<TaskListDto>(
            //    ObjectMapper.Map<List<TaskListDto>>(tasks)
            //);
        }
        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            try
            {
                //var task = ObjectMapper.Map<Acme.SimpleTaskApp.Tasks.Task>(input);
                //await _taskRepository.InsertAsync(task);
                //await CurrentUnitOfWork.SaveChangesAsync();

                //return ObjectMapper.Map<TaskListDto>(task);
                input.TenantId = 1;
                var task = ObjectMapper.Map<Acme.SimpleTaskApp.Tasks.Task>(input);
                await _taskRepository.InsertAsync(task);
                await CurrentUnitOfWork.SaveChangesAsync();
                //return ObjectMapper.Map<TaskListDto>(task);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

    }
}
