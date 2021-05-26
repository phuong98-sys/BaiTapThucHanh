using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Newtonsoft.Json;
using OutlookFW.Mails.Dto;
using OutlookFW.Models.Gmails;
using OutlookFW.Senders.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OutlookFW.Gmails
{
    public class GmailAppService : OutlookFWAppServiceBase, IGmailAppService
    {


        public async Task<string> GetUserDetailsAsync(string accessToken)
        {
            // Lay thông tin user

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://oauth2.googleapis.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GoogleUserOutputData serStatus = new GoogleUserOutputData();
            try
            {
                
                var url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accessToken;
                HttpResponseMessage output = client.GetAsync(url).Result;


                if (output.IsSuccessStatusCode)

                {

                    string outputData = output.Content.ReadAsStringAsync().Result;

                    serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);
                    //name = serStatus.email;

                }

            }

            catch (Exception ex)
            {
            }
            return serStatus.email;
        }
        #region to Display Emails
        // get inboxes of gmail
        public async Task<List<MailListDto>> GetMailAsync(string accessToken)
        {
            List<MailListDto> listGmail = new List<MailListDto>();
            
            HttpClient client = new HttpClient();
            Root rootObj = new Root();
            // Gui ma truy cap cho gmail api
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer",
                parameter: accessToken);
            HttpResponseMessage responseMessage = await client.GetAsync("https://mail.google.com/mail/feed/atom");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = responseMessage.Content; // du lieu tu gmail tra ve
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;// doc noi dung du lieu
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(@responseData);//
                string json = JsonConvert.SerializeXmlNode(doc);//chuyen du lieu xml thanh json
                rootObj = JsonConvert.DeserializeObject<Root>(json); // gan du lieu gmail cho doi tuong nay

                foreach (var message in rootObj.feed.entry)
                {
                    MailListDto gmail = new MailListDto();
                    //gmail.name = message.From.EmailAddress.Name;
                    gmail.from = message.author.name;
                   
                    gmail.body = message.summary;

                    gmail.subject = message.title;
                    gmail.date = message.issued.ToString();
                    listGmail.Add(gmail);
                }
                
            }
            return listGmail;
        }
        #endregion
        public async Task SendMailAsync(string accessToken, string subject, string to, string body,string from)
        { 

            var service = new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GoogleCredential.FromAccessToken(accessToken),
            });

            //send email
            var msg = new AE.Net.Mail.MailMessage
            {
                Subject = subject,
                Body = body,

                From = new MailAddress(from),

            };
            string Mails =to;
            var recipients = Mails.Split(' ');

            foreach (var recipient in recipients)
            {
                msg.To.Add(new MailAddress(recipient));
                msg.ReplyTo.Add(msg.From);
                var msgStr = new StringWriter();
                msg.Save(msgStr);
                await service.Users.Messages.Send(new Message()
                {
                    Raw = Base64UrlEncode(msgStr.ToString())
                }, "me").ExecuteAsync();
            }

        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }

    }
}
