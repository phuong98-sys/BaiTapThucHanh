using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Employees
{
    [Table("AppEmployees")]
    public class Employee : Entity, IHasCreationTime
    {
        public const int maxNameLenght = 32;
        [Required]
        [StringLength(maxNameLenght)]
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime BirthDate { get; set; }
        public Employee()
        {
            BirthDate = Clock.Now;
        }
    }
}
