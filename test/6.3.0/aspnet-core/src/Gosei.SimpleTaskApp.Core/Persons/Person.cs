using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Persons
{
    [Table("AppPersons")]
    public class Person : AuditedEntity<Guid>, IHasCreationTime
    {
        public const int MaxNameLength = 32;

      
   
        //public DateTime BirthDate { get; set; }
        public Person(string name, Guid? assignedPersonId = null)
        {
            Name = name;
            Id = Guid.NewGuid(); 
            //BirthDate = Clock.Now;
        }
        public Person()
        {
            CreationTime = Clock.Now;
            Id = Guid.NewGuid();
            //BirthDate = Clock.Now;
        }
        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
