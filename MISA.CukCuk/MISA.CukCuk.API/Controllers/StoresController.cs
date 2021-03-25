using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.ApplicationCore;
using Misa.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : BaseController<Store>
    {
        public StoresController(IBaseService baseService) : base(baseService)
        {

        }
    }
}
