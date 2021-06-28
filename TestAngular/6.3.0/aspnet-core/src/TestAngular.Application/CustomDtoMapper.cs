using Acme.SimpleTaskApp.Tasks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAngular.Tasks.DTO;

namespace TestAngular
{
    public class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Task,CreateTaskInput>();
        }
    }
}
