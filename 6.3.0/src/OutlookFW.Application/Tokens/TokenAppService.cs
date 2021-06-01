using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using OutlookFW.Mails;
using OutlookFW.Models.Gmails;
using OutlookFW.Tokens.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public string AuthorizationHeader
        {
            get
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{WebConfigurationManager.AppSettings["ZoomWebAppClientID"]}:{WebConfigurationManager.AppSettings["ZoomWebAppClientSecret"]}");
                var encodedString = System.Convert.ToBase64String(plainTextBytes);
                return $"Basic {encodedString}";
            }
        }
        public async Task<TokenDto> CreateOauthTokenForZoomAsync(string code)
        {
            RestClient restClient = new RestClient();
            var request = new RestRequest();
            restClient.BaseUrl = new Uri(string.Format(WebConfigurationManager.AppSettings["AccessTokenUrl"],code, WebConfigurationManager.AppSettings["ZoomRedirectUrl"]));
            request.AddHeader("Authorization", string.Format(AuthorizationHeader));

            var response = restClient.Post(request);
            string ResponseString = "";
            var token = new TokenDto();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //var a = response.Content;
                ResponseString = JsonConvert.DeserializeObject(response.Content).ToString();

                var result = JsonConvert.DeserializeObject<TokenDto>(ResponseString); // gan cho OAuthTokenViewModel

                token.access_token = result.access_token.ToString(); // access Token
                token.refresh_token = result.refresh_token.ToString();
                token.type = 2;

            }
            return token;
           
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
                        token.type = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            return token;
           
        }
       
        #endregion
        public async Task<TokenDto> CreateOauthTokenForGmailAsync(string code)
        {
            string GoogleWebAppClientID = WebConfigurationManager.AppSettings["GoogleWebAppClientID"];
            string GoogleWebAppClientSecret = WebConfigurationManager.AppSettings["GoogleWebAppClientSecret"];
            string RedirectUrl = WebConfigurationManager.AppSettings["GoogleRedirectUrl"];
            // AccessToken:
            RequestParameters requestParameters = new RequestParameters()
            {
                scope= "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email",
                code = code,
                client_id = GoogleWebAppClientID,
                client_secret = GoogleWebAppClientSecret,
                redirect_uri = RedirectUrl,
                grant_type = "authorization_code"
            };
            string inputJson = JsonConvert.SerializeObject(requestParameters);
            string requestURI = "token";
            string ResponseString = "";
            HttpResponseMessage respone;
            var token = new TokenDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://oauth2.googleapis.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                StringContent content = new StringContent(inputJson, Encoding.UTF8, "application/json");
                respone = client.PostAsync(requestURI, content).Result;

                if (respone.IsSuccessStatusCode)
                {
                    // chuyen doi chuoi tra ve
                    ResponseString = JsonConvert.DeserializeObject(respone.Content.ReadAsStringAsync().Result).ToString();
                    var result = JsonConvert.DeserializeObject<OAuthTokenViewModel>(ResponseString); // gan cho OAuthTokenViewModel
                    //ResponseString = result.Access_token.ToString(); // access Token
                    token.access_token = result.Access_token.ToString();
                    //token.refresh_token = result.Refresh_token;
                    token.type = 1;
                    try
                    {
                       
                        var url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + token.access_token;
                        HttpResponseMessage output = client.GetAsync(url).Result;
                        GoogleUserOutputData serStatus = new GoogleUserOutputData();

                        if (output.IsSuccessStatusCode)

                        {

                            string outputData = output.Content.ReadAsStringAsync().Result;

                            serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);
                            token.gmail = serStatus.email;

                        }

                    }
                    catch (Exception ex)
                    {
                    }

                }
                return token;
            }
        }
        public TokenDto GetToken(int userId, int type)
        {
            var token = _tokenRepository.FirstOrDefault(x => x.user_Id ==  userId && x.type == type);
            if (token != null)
            {
                var tokenDto = ObjectMapper.Map<TokenDto>(token);
                return tokenDto;
            }
            else return null;
          
        }
        public void DeleteToken(int userId, int type)
        {
            var task = _tokenRepository.FirstOrDefault(x => x.user_Id == userId && x.type == type);
            if (task == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _tokenRepository.Delete(task);
            }
        }
        public async Task SaveTokenAsync(SaveToken input)
        {
            var token = ObjectMapper.Map<Token>(input);
            await _tokenRepository.InsertAsync(token); // ko trả ve thi thuong dung cach nay
        }
        public void UpdateToken(UpdateTokenInput input)
        {
            //C1:
            var token =  _tokenRepository.FirstOrDefault(x => x.Id == input.Id);

            ObjectMapper.Map(input, token);

            //var task = GetTask(input.Id);
            //C2:
            //var output = ObjectMapper.Map<Task>(input);
            //await _taRepository.UpdateAsync(output);
        }
    }
}
