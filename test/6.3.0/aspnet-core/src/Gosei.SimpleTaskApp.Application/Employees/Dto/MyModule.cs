using Abp.AutoMapper;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gosei.SimpleTaskApp.Employees.Dto
{
    public class MyModule : AutoMapper.Profile
    {
        //public override void PreInitialize()
        //{
        //    Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
        //    {
        //        config.CreateMap<EmployeeListDto, Employee>()
        //              //.ForMember(u => u.Password, options => options.Ignore())
        //              .ForMember(u => u.Name, options => options.MapFrom(input => input.FirstName))
        //              .ForMember(u => u.BirthDate, options => options.MapFrom(input => input.BirthDate));
        //    });
        //}
        //public MyModule()
        //{
        //   CreateMap<EmployeeListDto, Employee>()
        //              //.ForMember(u => u.Password, options => options.Ignore())
        //              .ForMember(u => u.Name, options => options.MapFrom(input => input.FirstName))
        //              .ForMember(u => u.BirthDate, options => options.MapFrom(input => input.BirthDate));
        //}
    }
}

