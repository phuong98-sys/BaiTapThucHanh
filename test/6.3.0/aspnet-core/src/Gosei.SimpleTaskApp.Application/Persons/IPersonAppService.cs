using Abp.Application.Services;
using Gosei.SimpleTaskApp.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Persons
{
    public interface IPersonAppService: IApplicationService
    {
        Task<List<PersonListDto>> GetAll();
        Task CreatePerson(CreatePersonInput input);
        public PersonListDto GetPerson(GetPersonInput input);
        public System.Threading.Tasks.Task UpdatePerson(UpdatePersonInput input);
    }
}
