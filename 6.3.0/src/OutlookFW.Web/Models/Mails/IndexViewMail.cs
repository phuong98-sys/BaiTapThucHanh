using OutlookFW.Mails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutlookFW.Web.Models.Mails
{
    public class IndexViewMail
    {
        public IReadOnlyList<MailListDto> Mails { get; }


        public IndexViewMail(IReadOnlyList<MailListDto> mails)
        {
            Mails = mails;

        }
    }
}