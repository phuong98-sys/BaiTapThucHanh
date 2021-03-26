using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.ApplicationCore;
using Misa.ApplicationCore.Interface;
using Misa.ApplicationCore.Model;
using MISA.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.API.Controllers
{
    /// <summary>
    /// api tương tác với thông tin khách hàng
    /// </summary>
  
    public class CustomersController /*: BaseController<Customer>*/
    {
        //ICustomerService _customerService;
        //public CustomersController( ICustomerService customerService) : base(customerService)
        //{
        //    _customerService = customerService;
        //}

        /// <summary>
        /// Lấy thông tin danh sách khách hàng
        /// </summary>
        /// <returns></returns>
      
        ///// <summary>
        ///// Lấy thông tin khách hàng theo ID
        ///// </summary>
        ///// <param name="customerId">Id khách hàng</param>
        ///// <returns></returns>
        //[HttpGet("{customerId}")]
        //public IActionResult GetCustomerById(Guid customerId)
        //{
        //    var baseService = new BaseService();
        //    var customer = baseService.GetObjectById<Customer>(customerId);
        //    if (customer != null)
        //    {
        //        return StatusCode(200, customer);
        //    }
        //    else
        //    {
        //        return StatusCode(204, customer);
        //    }
        //}
        ///// <summary>
        ///// Thêm mới một khách hàng
        ///// </summary>
        ///// <param name="customer">Thông tin 1 khách hàng</param>
        ///// <returns>Số khách hàng được thêm thành công</returns>
        //[HttpPost]
        //public IActionResult InsertCustomer(Customer customer)
        //{

        //    var baseService = new BaseService();
        //    var serviceResult = baseService.InsertObject<Customer>(customer);
        //    if (serviceResult.MISACode == MisaCode.IsValid && (int)serviceResult.Data>0)
        //    {
        //        return Created("Thêm khách hàng mới thành công", customer);
        //    }
        //    if( serviceResult.MISACode == MisaCode.NotValid)
        //    {
        //        return BadRequest(serviceResult.Data);
        //    }    
        //    else
        //    {
        //        return NoContent();
        //    }
        //}
        // [HttpDelete]
        //public IActionResult DeleteCustomer(Guid customerId)
        //{
        //    var customerService = new CustomerService();
        //    var res = customerService.DeleteCustomer(customerId);
        //    if(res>0)
        //    {
        //        return StatusCode(200, "Xoa khach hang thanh cong");

        //    }
        //    else
        //    {
        //        return StatusCode(400, "Xoa khong thanh cong");
        //    }
        //}

    }
}