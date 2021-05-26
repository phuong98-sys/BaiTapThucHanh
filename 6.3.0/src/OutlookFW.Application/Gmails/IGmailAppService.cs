using Abp.Application.Services;
using OutlookFW.Mails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Gmails
{
    public interface IGmailAppService : IApplicationService
    {
        Task<string> GetUserDetailsAsync(string accessToken);
        Task<List<MailListDto>> GetMailAsync(string accessToken);
        Task SendMailAsync(string accessToken, string subject, string to, string body, string from);
    }
}
