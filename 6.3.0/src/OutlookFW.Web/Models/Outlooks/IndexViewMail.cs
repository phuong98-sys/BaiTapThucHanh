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
        public string Email { get; }
        public IndexViewMail()
        {
            Mails = null;
            Email = "";
            isAuthenticated = false;
        }
        public IndexViewMail(IReadOnlyList<MailListDto> mails, string email)
        {
            Mails = mails;
            Email = email;
            isAuthenticated = true;

        }
    }
}