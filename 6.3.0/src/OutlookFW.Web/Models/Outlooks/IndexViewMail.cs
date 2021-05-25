using OutlookFW.Mails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutlookFW.Web.Models.Outlooks
{
    public class IndexViewMail
    {
        public IReadOnlyList<MailListDto> Mails { get; }
        public bool isAuthenticated { get; set; }
        public bool IsSendSuccess { get; set; }
        public string Email { get; }
        public IndexViewMail()
        {
            Mails = null;
            Email = "";
            isAuthenticated = false;
            IsSendSuccess = false;
        }
        public IndexViewMail(IReadOnlyList<MailListDto> mails, string email, bool isSendSuccess)
        {
            Mails = mails;
           
            isAuthenticated = true;
            IsSendSuccess = isSendSuccess;

        }
    }
}