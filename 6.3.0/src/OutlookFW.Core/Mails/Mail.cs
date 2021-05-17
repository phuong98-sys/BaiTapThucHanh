using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using OutlookFW.Senders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Mails
{

    [Table("AppMails")]
    public class Mail: Entity, IHasCreationTime
    {
      
        public string name { get; set; }
       
        public string subject { get; set; }
        public string from { get; set; }
        [Required]
        public string to { get; set; }
        public string date { get; set; }
        public string body { get; set; }
        public DateTime CreationTime { get; set; }
        public Mail(string name)
        {
            this.name = name;
           
        }
        public Mail()
        {
            CreationTime = Clock.Now;
         
        }
        [ForeignKey(nameof(GSenderId))]
        public Sender GSender { get; set; } // them tu Person table
        public int GSenderId { get; set; }
       
    }
}
