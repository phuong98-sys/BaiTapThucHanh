using Abp.Application.Services.Dto;
using Abp.AutoMapper;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Gosei.SimpleTaskApp.Employees.Dto
{
    //[AutoMapFrom(typeof(Employee))]
    public class EmployeeListDto:EntityDto
    {

        public const int maxLengthName = 32;
        [StringLength(Employee.maxNameLenght)]
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}


