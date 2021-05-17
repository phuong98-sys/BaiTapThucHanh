using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace OutlookFW.Senders
{
    [Table("AppSenders")]
    public class Sender : Entity, IHasCreationTime
    {
        public const int MaxEmailLength = 256;

        public string DisplayName { get; set; }
        [Required]
        [StringLength(MaxEmailLength)]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime CreationTime { get; set; }
        public Sender()
        {
            CreationTime = Clock.Now;

        }
        public Sender(string email)
            : this()
        {
            Email = email;
           
        }
    }
}
