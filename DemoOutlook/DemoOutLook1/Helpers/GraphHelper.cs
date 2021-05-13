using DemoOutLook1.Model;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Message = Microsoft.Graph.Message;

namespace DemoOutLook1.Helpers
{
    public static class GraphHelper
    {
        //private static GraphServiceClient graphClient;
        //public static void Initialize(IAuthenticationProvider authProvider)
        //{
        //    graphClient = new GraphServiceClient(authProvider);
        //}
        public static async Task<User> GetMeAsync(string accessToken)
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
                // GET /me
                //var userMessage = await graphClient.Me.Messages
                //            .Request()
                //            .Select(m => new {
                //                m.Subject,
                //                m.Sender
                //            })
                //            .GetAsync();

                var user = await graphClient.Me.Messages.Request()
                    .Select("sender,from,subject")
                    .GetAsync();
                foreach( var message in user)
                {
                    var sender = message.Sender;
                    var from = message.From;
                    var subject = message.Subject;
                }
                return await graphClient.Me.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
               // Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }
        public static async void SendMailAsync( string accessToken)
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
                var message = new Message
                {
                    Subject = "Testing from .NET SDK",
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = "The SDK is working fine!"
                    },
                    ToRecipients = new List<Recipient>()
                    {
                        new Recipient
                        {
                            EmailAddress = new EmailAddress
                            {
                                Address = "YOUR_EMAIL@outlook.com"
                            }
                        }
                    }
                };
                await graphClient.Me
                    .SendMail(message, null)
                    .Request()
                    .PostAsync();
            }
            catch (ServiceException ex)
            {
               // Console.WriteLine($"Error getting signed-in user: {ex.Message}");
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
                .Select(u => new {
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