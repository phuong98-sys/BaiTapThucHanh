using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Gosei.SimpleTaskApp.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosei.SimpleTaskApp.Persons
{
    public interface ILookupAppService : IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetPeopleComboboxItems();
        public Task<List<PersonListDto>> GetAll();
    }
}
