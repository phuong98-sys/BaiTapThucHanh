using Abp.AutoMapper;
using OutlookFW.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Tokens.Dto
{
    [AutoMapTo(typeof(Token))]
    public class TokenDto   // map voi Task entity
    {
       
        public string access_token { get; set; }

      
        public string refresh_token { get; set; }

        public int? user_Id { get; set; }
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
