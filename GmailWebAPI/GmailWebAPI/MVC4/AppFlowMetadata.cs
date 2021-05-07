using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;

namespace GmailWebAPI.MVC4
{
    public class AppFlowMetadata : FlowMetadata
    {
        public static IDataStore DataStore;
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    //ClientId = "369518912260-5g5delg9bh600r6amuqsvmc0n995f2b7.apps.googleusercontent.com",
                    //ClientSecret = "XA4yC-8Oj6pMWhdJS5CS7ZZH",


                },
                //Prompt = consent,
                Scopes = new[] { "https://mail.google.com/" },
                DataStore = new FileDataStore("Google.Apis.Gmail.v1")
                //DataStore = new FileDataStore("Google.Apis.Auth.Data", true)
            });
        public async Task DeleteTokenAsync(string userId, CancellationToken taskCancellationToken)
        {
            taskCancellationToken.ThrowIfCancellationRequested();
            if (DataStore != null)
            {
                await DataStore.DeleteAsync<TokenResponse>(userId).ConfigureAwait(false);
            }
        }
        //public override async Task RevokeTokenAsync(string userId, string token,
        //        CancellationToken taskCancellationToken)
        //{
        //    GoogleRevokeTokenRequest request = new GoogleRevokeTokenRequest(new Uri(RevokeTokenUrl))
        //    {
        //        Token = token
        //    };
        //    var httpRequest = new HttpRequestMessage(HttpMethod.Post, request.Build());

        //    var response = await HttpClient.SendAsync(httpRequest, taskCancellationToken).ConfigureAwait(false);
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var error = NewtonsoftJsonSerializer.Instance.Deserialize<TokenErrorResponse>(content);
        //        throw new TokenResponseException(error, response.StatusCode);
        //    }

        //    await DeleteTokenAsync(userId, taskCancellationToken).ConfigureAwait(false);
        //}
        public override string GetUserId(Controller controller)
        {

            return "1";

        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}
