using Abp.Domain.Repositories;
using Gosei.SimpleTaskApp.Persons.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Persons
{
    public class PersonAppService:SimpleTaskAppAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person,Guid> _personRepository;
        public PersonAppService(IRepository<Person, Guid> personRepository)
        {
            _personRepository = personRepository;
        }
        public  async Task<List<PersonListDto>> GetAll()
        {
            var people = await _personRepository.GetAll().ToListAsync();
            return new List<PersonListDto>(
                ObjectMapper.Map<List<PersonListDto>>(people)
                );
        }
        public async System.Threading.Tasks.Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }
    }
}
