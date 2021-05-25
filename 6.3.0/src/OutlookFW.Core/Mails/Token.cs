using Abp.Domain.Entities;
using OutlookFW.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookFW.Mails
{
    [Table("AppTokens")]
    public class Token : Entity
    {
        
        public string access_token { get; set; }
        public string refresh_token { get; set; }

        [ForeignKey(nameof(user_Id))]
        public User user { get; set; } // them tu User table

        public long? user_Id { get; set; }
      
    }

}
