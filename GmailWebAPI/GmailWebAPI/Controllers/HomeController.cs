using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;

using Google.Apis.Sample.MVC4;
using GmailWebAPI.MVC4;
using Google.Apis.Gmail.v1;
using System.Collections.Generic;
using Google.Apis.Gmail.v1.Data;

namespace Google.Apis.Sample.MVC4.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });
                UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

                
                IList<Label> labels = request.Execute().Labels;

                if (labels != null && labels.Count > 0)
                {
                    foreach (var labelItem in labels)
                    {
                        ViewBag.Message = labelItem.Name;
                        break;

                    }
                }
                else
                {
                    ViewBag.Message = "Khong tim thay";
                }
                //YOUR CODE SHOULD BE HERE..SAMPLE CODE:
                //var list = await service.Files.List().ExecuteAsync();
                //foreach (var item in list.Items)
                //{
                //    item.Id
                //}
                //ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();



                // mới
                //var request = service.Users.Messages.List("EMAILADDRESSHERE");
                //request.LabelIds = "INBOX";
                //request.IncludeSpamTrash = false;
                //emailListRequest.Q = "is:unread"; // This was added because I only wanted unread emails...

                // Get our emails
                //var emailListResponse = await request.ExecuteAsync();

                //if (emailListResponse != null && emailListResponse.Messages != null)
                //{
                //    // Loop through each email and get what fields you want...
                //    foreach (var email in emailListResponse.Messages)
                //    {
                //        var emailInfoRequest = service.Users.Messages.Get("EMAIL ADDRESS HERE", email.Id);
                //        // Make another request for that email id...
                //        var emailInfoResponse = await emailInfoRequest.ExecuteAsync();

                //        if (emailInfoResponse != null)
                //        {
                //            var from = "";
                //            var date = "";
                //            var subject = "";
                //            var body = "";
                //            // Loop through the headers and get the fields we need...
                //            foreach (var mParts in emailInfoResponse.Payload.Headers)
                //            {
                //                if (mParts.Name == "Date")
                //                {
                //                    date = mParts.Value;
                //                    ViewBag.Message = date;
                //                }
                //                else if (mParts.Name == "From")
                //                {
                //                    from = mParts.Value;
                //                }
                //                else if (mParts.Name == "Subject")
                //                {
                //                    subject = mParts.Value;
                //                }

                //                //if (date != "" && from != "")
                //                //{
                //                //    if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                //                //    {
                //                //        body = emailInfoResponse.Payload.Body.Data;
                //                //    }
                //                //    else
                //                //    {
                //                //        body = getNestedParts(emailInfoResponse.Payload.Parts, "");
                //                //    }
                //                //    // Need to replace some characters as the data for the email's body is base64
                //                //    var codedBody = body.Replace("-", "+");
                //                //    codedBody = codedBody.Replace("_", "/");
                //                //    byte[] data = Convert.FromBase64String(codedBody);
                //                //    body = Encoding.UTF8.GetString(data);

                //                //    // Now you have the data you want...                         
                //                //}
                //            }
                //        }
                //    }
                //}

                return View();
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
