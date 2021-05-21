using Abp.Domain.Repositories;
using Microsoft.Graph;
using OutlookFW.Mails.Dto;
using OutlookFW.Senders;
using OutlookFW.Senders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Mails
{
    public class MailAppService : OutlookFWAppServiceBase, IMailAppService
    {

        private readonly IRepository<Mail> _mailRepository;
        public MailAppService(IRepository<Mail> mailRepository)
        {
            _mailRepository = mailRepository;

        }
        //public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        //{
        //    var tasks = await _taskRepository
        //        .GetAll()
        //        .Include(t => t.AssignedPerson) //truy van them ca bang nay de hien thi, tu dong copy vao DTO by AutoMapper
        //        .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
        //        .OrderByDescending(t => t.CreationTime)
        //        .ToListAsync();

        //    return new ListResultDto<TaskListDto>(
        //        ObjectMapper.Map<List<TaskListDto>>(tasks)
        //    );
        //}
        public async Task<List<MailListDto>> GetMailAsync(string accessToken)
            {
                var graphClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(
                        async (requestMessage) =>
                        {
                            requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", accessToken);
                        }));
                try
                {
                    List<MailListDto> listMail = new List<MailListDto>();

                    var mailBox = await graphClient.Me.MailFolders.Inbox.Messages.Request()
                       .Select("sender,from,toRecipients,receivedDateTime, subject,body")
                       .GetAsync();

                    foreach (var message in mailBox)
                    {
                    MailListDto mail = new MailListDto();
                        mail.name = message.From.EmailAddress.Name;
                        mail.from = message.From.EmailAddress.Address;
                        mail.date = message.ReceivedDateTime.ToString();
                        mail.body = message.Body.Content.ToString();

                        mail.subject = message.Subject.ToString();
                        listMail.Add(mail);
                    }
                    return listMail;
                }
                catch (ServiceException ex)
                {
                    return null;
                }
            }



        public async Task SendMailAsync(string accessToken, string subject, string to, string body)
        {
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", accessToken);
                    }));
            try
            {
                string Mails = to;
                var toRecipients = Mails.Split(' ');
                List<Recipient> a = new List<Recipient>();
                foreach (var address in toRecipients)
                {

                    Recipient b = new Recipient
                    {

                        EmailAddress = new EmailAddress
                        {
                            Address = address,

                        }
                    };
                    a.Add(b);
                }
                var message = new Message
                {
                    Subject = subject,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = body
                    },
                    ToRecipients = a,


                };


                await graphClient.Me
                    .SendMail(message, null)
                            .Request()
                            .PostAsync();

            }
            catch (ServiceException ex)
            {

            }

        }
        public async Task<SenderListDto> GetUserDetailsAsync(string accessToken)
        {
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", accessToken);
                    }));

            var user = await graphClient.Me.Request()
                .Select(u => new
                {
                    u.DisplayName,
                    u.Mail,
                    u.UserPrincipalName
                })
                .GetAsync();

            return new SenderListDto
            {
                Avatar = string.Empty,
                DisplayName = user.DisplayName,
                Email = string.IsNullOrEmpty(user.Mail) ?
                    user.UserPrincipalName : user.Mail
            };
        }

    }
}
