using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using TestAngular.Tasks;

namespace Acme.SimpleTaskApp.Tasks
{
    [Table("AppTasks")]
    public class Task : Entity, IHasCreationTime, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
            TenantId = 1;
        }

        public Task(int tenantId, string title, string description = null)
            : this()
        {
            TenantId = tenantId;
            Title = title;
            Description = description;
        }
    }

    //public enum TaskState : byte
    //{
    //    Open = 0,
    //    Completed = 1
    //}
}