using Abp.AutoMapper;
using OutlookFW.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Tokens.Dto
{
    [AutoMapFrom(typeof(Token))]
    public class TokenDto   // map voi Task entity
    {
        public int Id { get; set; }
        public string access_token { get; set; }

      
        public string refresh_token { get; set; }

        public int? user_Id { get; set; }
        public int? type { get; set; }
        public string gmail { get; set; }
    }
    [AutoMapTo(typeof(Token))]
    public class SaveToken   // map voi Task entity
    {
      
        public string access_token { get; set; }


        public string refresh_token { get; set; }

        public int? user_Id { get; set; }
        public int? type { get; set; }
        public string gmail { get; set; }
        public string userZoomId { get; set; }
    }
    [AutoMapTo(typeof(Token))]
    public class UpdateTokenInput   // map voi Task entity
    {
        public long Id { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }

      
    }
    [AutoMapFrom(typeof(Token))]
    public class GetTokenInput
    {
        public string access_token { get; set; }
    }
    [AutoMapFrom(typeof(Token))]
    public class DeleteTokenInput
    {
        public int Id { get; set; }


    }
}
