using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Persons
{
    [Table("AppPersons")]
    public class Person:AuditedEntity<Guid> // thay vi su dung base Entity class
    {
        public const int MaxNameLengh = 32;
        [Required]
        [StringLength(MaxNameLengh)]
        public string Name { get; set; }
        public Person()
        {

        }
        public Person(string name)
        {
            Name = Name;
        }
    }
}
