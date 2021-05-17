using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Senders.Dto
{
    [AutoMapFrom(typeof(Sender))]
    public class SenderListDto : EntityDto
    {
        public string DisplayName { get; set; }
        [Required]
        [StringLength(Sender.MaxEmailLength)]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public SenderListDto()
        {

        }
    }
}
