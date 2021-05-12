using DotNetOpenAuth.AspNet.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace DemoOutlook.Models
{
    public static class MicrosoftClientExtensions
    {
        public static ExtendedMicrosoftClientUserData GetExtraData(this MicrosoftClient client, string accessToken)
        {
            ExtendedMicrosoftClientUserData graph;
            var request =
                WebRequest.Create(
                    "https://apis.live.net/v5.0/me?access_token=" + EscapeUriDataStringRfc3986(accessToken));
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        string data = sr.ReadToEnd();

                        graph = JsonConvert.DeserializeObject<ExtendedMicrosoftClientUserData>(data);
                    }
                }
            }

            return graph;
        }
        private static readonly string[] UriRfc3986CharsToEscape = new[] { "!", "*", "'", "(", ")" };
        private static string EscapeUriDataStringRfc3986(string value)
        {
            StringBuilder escaped = new StringBuilder(Uri.EscapeDataString(value));

            // Upgrade the escaping to RFC 3986, if necessary.
            for (int i = 0; i < UriRfc3986CharsToEscape.Length; i++)
            {
                escaped.Replace(UriRfc3986CharsToEscape[i], Uri.HexEscape(UriRfc3986CharsToEscape[i][0]));
            }

            // Return the fully-RFC3986-escaped string.
            return escaped.ToString();
        }
    }
    public class ExtendedMicrosoftClientUserData
    {
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }
        public Uri Link { get; set; }
        public string Name { get; set; }
        public Emails Emails { get; set; }
    }
    public class Emails
    {
        public string Preferred { get; set; }
        public string Account { get; set; }
        public string Personal { get; set; }
        public string Business { get; set; }
    }
}