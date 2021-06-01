using Abp.Application.Services;
using OutlookFW.Models.Zoom;
using OutlookFW.Tokens.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Zoom
{
    public interface IZoomAppService : IApplicationService
    {
        Task<UserMeeting> GetUserDetailsAsync(string accessToken);
        void CreateMeeting(Meeting meeting, string accessToken, string userId);
        List<Meeting> AllMeetings(string accessToken, string userId);
        Task<TokenDto> RefreshToken(string refreshToken);
    }
}
