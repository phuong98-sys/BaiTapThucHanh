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
        public string Name { get; set; }
        //public DateTime BirthDate { get; set; }

    }
}

