using Abp.Application.Services;
using OutlookFW.Models.Zoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Zoom
{
    public interface IZoomAppService : IApplicationService
    {
        Task<string> GetUserDetailsAsync(string accessToken);
        void CreateMeeting(Meeting meeting, string accessToken, string userId);
        Task<List<Meeting>> AllMeetings(string accessToken, string userId);
    }
}
