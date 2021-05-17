using Abp.Application.Services;
using OutlookFW.Mails.Dto;
using OutlookFW.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Mails
{

    public interface  IMailAppService : IApplicationService
    {
        Task<List<MailListDto>> GetMeAsync(string accessToken);
        //Task SendMailAsync(string accessToken, string subject, string to, string body);
        //Task<Sender> GetUserDetailsAsync(string accessToken);

    }
}
