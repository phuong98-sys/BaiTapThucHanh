using Abp.Application.Services;
using OutlookFW.Tokens.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Tokens
{
    public interface ITokenAppService : IApplicationService
    {
        Task<TokenDto> CreateOauthTokenForMailAsync(string code);
        Task SaveTokenAsync(TokenDto input);
        string GetToken(int userId);
        void DeleteToken(int userId);
    }
}
