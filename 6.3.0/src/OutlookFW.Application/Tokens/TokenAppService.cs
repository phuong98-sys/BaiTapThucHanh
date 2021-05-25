using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using OutlookFW.Mails;
using OutlookFW.Tokens.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace OutlookFW.Tokens
{
    public class TokenAppService : OutlookFWAppServiceBase, ITokenAppService
    {
        private readonly IRepository<Token> _tokenRepository;
        public TokenAppService(IRepository<Token> tokenRepository)
        {
            _tokenRepository = tokenRepository;

        }

        #region to Create AccessToken by using this Parameters
        // Lay ma truy cap
        public async Task<TokenDto> CreateOauthTokenForMailAsync(string code)
        {
            string MicrosoftWebAppClientID = WebConfigurationManager.AppSettings["MicrosoftWebAppClientID"];
            string MicrosoftWebAppClientSecret = WebConfigurationManager.AppSettings["MicrosoftWebAppClientSecret"];
            string RedirectUrl = WebConfigurationManager.AppSettings["RedirectUrl"];
            var data = new Dictionary<string, string>
            {
                {"client_id", MicrosoftWebAppClientID},
                {"scope", "https://graph.microsoft.com/mail.read"},
                {"code", code},
                {"redirect_uri", RedirectUrl},
                {"grant_type", "authorization_code"},
                {"client_secret", MicrosoftWebAppClientSecret}
            };
           
            string ResponseString = "";
            HttpResponseMessage respone;
            var token = new TokenDto();
            try
            {
                using (var client = new HttpClient())
                {


                    var request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/common/oauth2/v2.0/token")
                    {
                        Content = new FormUrlEncodedContent(data)
                    };

                    respone = client.SendAsync(request).Result;

                    if (respone.IsSuccessStatusCode)
                    {
                        // chuyen doi chuoi tra ve
                        ResponseString = JsonConvert.DeserializeObject(respone.Content.ReadAsStringAsync().Result).ToString();

                        var result = JsonConvert.DeserializeObject<TokenDto>(ResponseString); // gan cho OAuthTokenViewModel
                      
                        token.access_token = result.access_token.ToString(); // access Token
                        token.access_token = result.access_token.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            return token;
           
        }
        #endregion
        public string GetToken(int userId)
        {
            var task = _tokenRepository.FirstOrDefault(x => x.user_Id ==  userId);
            if (task != null) return task.access_token;
            else return null;
          
        }
        public void DeleteToken(int userId)
        {
            var task = _tokenRepository.FirstOrDefault(x => x.user_Id == userId);
            if (task == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _tokenRepository.Delete(task);
            }
        }
        public async Task SaveTokenAsync(TokenDto input)
        {
            var token = ObjectMapper.Map<Token>(input);
            await _tokenRepository.InsertAsync(token); // ko trả ve thi thuong dung cach nay
        }
    }
}
