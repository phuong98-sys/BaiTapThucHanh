using Abp.AutoMapper;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace Gosei.SimpleTaskApp.Persons.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto
    {
        //public const int maxLengthName = 32;
        [StringLength(Person.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

    }
    [AutoMapTo(typeof(Person))]
    public class CreatePersonInput{
        [Required]
        public Guid? Id { get; set; }
        [StringLength(Person.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationTime { get; set; }
    }
}

