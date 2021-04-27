using Gosei.SimpleTaskApp.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Web.Models.People
{
    public class PersonViewModel
    {
        public IReadOnlyList<PersonListDto> People;
        public PersonViewModel(IReadOnlyList<PersonListDto> people)
        {
            People = people;
        }
    }
}
