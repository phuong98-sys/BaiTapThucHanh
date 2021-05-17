using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Mails.Dto
{
    //[AutoMapFrom(typeof(Mail))]
    public class MailListDto : EntityDto, IHasCreationTime
    {
        public MailListDto()
        {
        }
            public string name { get; set; }

            public string subject { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string date { get; set; }
            public string body { get; set; }
            public DateTime CreationTime { get; set; }

        }
}
