using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Tasks.Dto
{
   
    // lay ra cac state thoa man
    public class GetAllTasksInput{
        public TaskState? State { get; set; }
    }
    //Tang nay Goi va thuc hien voi Dto va tra ve tang .Core voi Task Entity duoc Map
    [AutoMapFrom(typeof(Task))]
    public class TaskListDto: EntityDto, IHasCreationTime
    {
        // Them thong tin ve nguoi duoc giao
        public Guid? AssignedPersonId { get; set; }
        public string AssignedPersonName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public TaskState State { get; set; }
    }
}
