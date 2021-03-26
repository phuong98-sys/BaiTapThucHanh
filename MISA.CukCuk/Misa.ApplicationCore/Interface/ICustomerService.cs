using Misa.ApplicationCore.Model;
using MISA.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.ApplicationCore.Interface
{
    public interface ICustomerService/*: IBaseService*/
    {
        public Customer GetCustomerByCode(string customerCode);
       

    }
}
