using Abp.Application.Services.Dto;

namespace Gosei.SimpleTaskApp.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

