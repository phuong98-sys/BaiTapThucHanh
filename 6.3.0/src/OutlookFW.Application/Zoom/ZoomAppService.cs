using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OutlookFW.Models.Zoom;
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
        public async Task<string> GetUserDetailsAsync(string accessToken)
        {
            RestClient restClient = new RestClient();
            var request = new RestRequest();
            restClient.BaseUrl = new Uri("https://api.zoom.us/v2/users/me");
            request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
            var response = restClient.Get(request);
            string ResponseString = "";
            string userId = "";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var user = JObject.Parse(response.Content);
                userId = user["id"].ToString();
                //ResponseString = JsonConvert.DeserializeObject(response.Content).ToString();

                // email = JsonConvert.DeserializeObject<string>(ResponseString); // gan cho 

               
            }
            return userId;
        }
        public void CreateMeeting(Meeting meeting, string accessToken, string userId)
        {
            //var userId = GetUserDetailsAsync(accessToken);
            var meetingModel = new JObject();
            meetingModel["topic"] = meeting.Topic;
            meetingModel["agenda"] = meeting.Agenda;
            meetingModel["start_time"] = meeting.StartTime.ToString("yyyy-MM-dd") + "T" + TimeSpan.FromHours(meeting.Time1).ToString("hh':'mm':'ss");
            meetingModel["end_time"] = meeting.StartTime.ToString("yyyy-MM-dd") + "T" + TimeSpan.FromHours(meeting.Time2).ToString("hh':'mm':'ss");
            //meetingModel["end_time"] = meeting.EndTime.ToString("dd-MM-yyyy");
            //meetingModel["duration"] = meeting.Duration;
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
                var a = response.Content;
            }
        }
        public async Task<List<Meeting>> AllMeetings(string accessToken, string userId)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Authorization", "Bearer " + accessToken);
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri($"https://api.zoom.us/v2/users/{userId}/meetings");
            var response = restClient.Get(restRequest);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var zoomMeetings = JObject.Parse(response.Content)["meetings"].ToObject<IEnumerable<Meeting>>();

            }
            return null;

        }
            
    }
}
