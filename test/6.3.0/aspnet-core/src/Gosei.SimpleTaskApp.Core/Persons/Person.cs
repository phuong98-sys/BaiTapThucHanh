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
    public class Person : AuditedEntity<Guid>
    {
        public const int MaxNameLength = 32;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public Person()
        {

        }
        //public DateTime BirthDate { get; set; }
        public Person(string name)
        {
            Name = name;
            //BirthDate = Clock.Now;
        }
     
    }
}
