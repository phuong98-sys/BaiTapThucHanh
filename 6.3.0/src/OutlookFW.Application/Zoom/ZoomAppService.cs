using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OutlookFW.Models.Zoom;
using OutlookFW.Tokens.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace OutlookFW.Zoom
{
    public class ZoomAppService : OutlookFWAppServiceBase, IZoomAppService
    {
        public string AuthorizationHeader
        {
            get
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{WebConfigurationManager.AppSettings["ZoomWebAppClientID"]}:{WebConfigurationManager.AppSettings["ZoomWebAppClientSecret"]}");
                var encodedString = System.Convert.ToBase64String(plainTextBytes);
                return $"Basic {encodedString}";
            }
        }
        //nen  bo tham so vao trong
        public async Task<UserMeeting> GetUserDetailsAsync(string accessToken)
        {
            RestClient restClient = new RestClient();
            var request = new RestRequest();
            restClient.BaseUrl = new Uri("https://api.zoom.us/v2/users/me");
            request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
            var response = restClient.Get(request);
            string ResponseString = "";
            var userMeeting = new UserMeeting();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var user = JObject.Parse(response.Content);
                userMeeting.userId = user["id"].ToString();
                userMeeting.userEmail = user["email"].ToString();
             

            }
            return userMeeting;
        }
        public void CreateMeeting(Meeting meeting, string accessToken, string userId)
        {
            //var userId = GetUserDetailsAsync(accessToken);
            var meetingModel = new JObject();
            meetingModel["topic"] = meeting.Topic;    
            DateTime dt1 = meeting.start_time;
            DateTime dt2 = meeting.EndTime;
            TimeSpan ts = dt2 - dt1;
            var totalMinutes =ts.TotalMinutes; // nen tinh cai nay tu ben Model
            var vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
          
            var startTimeUtcTime = TimeZoneInfo.ConvertTimeToUtc(meeting.start_time, vnTimeZone);
            var endTimeUtcTime = TimeZoneInfo.ConvertTimeToUtc(meeting.EndTime, vnTimeZone);

            meetingModel["start_time"] = startTimeUtcTime;
            meetingModel["duration"] = totalMinutes;
           
            meetingModel["password"] = meeting.Password;
            meetingModel["description"] = meeting.Description;

            var model = JsonConvert.SerializeObject(meetingModel);

            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
            restRequest.AddParameter("application/json", model, ParameterType.RequestBody);

            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri(string.Format(WebConfigurationManager.AppSettings["MeetingUrl"], userId));
            var response = restClient.Post(restRequest);
            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var a1= response.Content;
            }
        }
        public List<Meeting> AllMeetings(string accessToken, string userId)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Authorization", "Bearer " + accessToken);
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri($"https://api.zoom.us/v2/users/{userId}/meetings");
            var response = restClient.Get(restRequest);
            List<Meeting> listMeeting = new List<Meeting>();
           
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var zoomMeetings = JObject.Parse(response.Content)["meetings"].ToObject<IEnumerable<Meeting>>();
              
                var vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
               
                foreach (var meeting1 in zoomMeetings)
                {
                    Meeting meeting = new Meeting(); 
                    //gmail.name = message.From.EmailAddress.Name;
                    meeting.Topic = meeting1.Topic;
                    var vnTime = TimeZoneInfo.ConvertTimeFromUtc(meeting1.start_time, vnTimeZone);
                    meeting.start_time = vnTime;
                    meeting.Duration = meeting1.Duration;
                    meeting.Agenda = meeting1.Agenda;
                    meeting.join_url = meeting1.join_url;

                    listMeeting.Add(meeting);
                }
            }
            return listMeeting;

        }
        public async Task<TokenDto> RefreshToken(string refreshToken)
        {
            RestClient restClient = new RestClient();
            // get Token
            var request = new RestRequest();
            //token
            restClient.BaseUrl = new Uri(string.Format(WebConfigurationManager.AppSettings["TokenUrl"], refreshToken));
            //restClient.BaseUrl = new Uri(WebConfigurationManager.AppSettings["TokenUrl"]);
            //request.AddQueryParameter("grant_type", "refresh_token");
            //request.AddQueryParameter("refresh_token", refreshToken);
            request.AddHeader("Authorization", string.Format(AuthorizationHeader));
            TokenDto token = new TokenDto();
            var response = restClient.Post(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)// lam them truong hop ko thanh cong thi vang ra loi
            {
                var user = JObject.Parse(response.Content);
                token.access_token = user["access_token"].ToString();
                token.refresh_token = user["refresh_token"].ToString();
                
            }
            return token;

        }
            
    }
}
