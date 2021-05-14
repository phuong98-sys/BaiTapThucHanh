using DemoOutLook1.Model;
using iText.StyledXmlParser.Jsoup;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Message = Microsoft.Graph.Message;

namespace DemoOutLook1.Helpers
{
    public static class GraphHelper
    {
        
        public static async Task<List<Mail>> GetMeAsync(string accessToken)
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
                List<Mail> listMail = new List<Mail>();
               
                var mailBox = await graphClient.Me.MailFolders.Inbox.Messages.Request()
                   .Select("sender,from,toRecipients,receivedDateTime, subject,body")
                   .GetAsync();

                foreach (var message in mailBox)
                {
                    Mail mail = new Mail();
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
      
        public static async Task SendMailAsync(string accessToken, string subject, string to, string body)
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
        public static async Task<CachedUser> GetUserDetailsAsync(string accessToken)
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

            return new CachedUser
            {
                Avatar = string.Empty,
                DisplayName = user.DisplayName,
                Email = string.IsNullOrEmpty(user.Mail) ?
                    user.UserPrincipalName : user.Mail
            };
        }
    }
}