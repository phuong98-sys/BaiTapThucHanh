using AutoMapper;
using Gosei.SimpleTaskApp.Employees;
using Gosei.SimpleTaskApp.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp
{
    internal static class CustomDtoMapper
    {
       public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */

            configuration.CreateMap<Employee, EmployeeListDto>()
                      //.ForMember(u => u.Password, options => options.Ignore())
                      .ForMember(u => u.FirstName, options => options.MapFrom(input => input.Name));
        }
    }
}
