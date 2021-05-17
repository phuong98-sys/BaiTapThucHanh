using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OutlookFW.Roles.Dto;
using OutlookFW.Users.Dto;

namespace OutlookFW.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}