
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace Gosei.SimpleTaskApp.Persons.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : AuditedEntityDto
    {
        public PersonListDto()
        {
            //this.Id = Guid.NewGuid();
        }
        //public const int maxLengthName = 32;
        [StringLength(Person.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid? Id { get; set; }

    }
    [AutoMapTo(typeof(Person))]
    public class CreatePersonInput{
      
        //public Guid? Id { get; set; }
        [StringLength(Person.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationTime { get; set; }
    }
    [AutoMapTo(typeof(Person))]
    public class UpdatePersonInput
    {
        public Guid Id { get; set; }
        [StringLength(Person.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

    }
    public class GetPersonInput
    {
        public Guid Id { get; set; }
    }
    public class DeletePersonInput
    {
        public Guid Id { get; set; }
    }
}

