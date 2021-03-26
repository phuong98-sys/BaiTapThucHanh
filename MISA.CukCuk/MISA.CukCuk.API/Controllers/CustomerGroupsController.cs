using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.ApplicationCore;
using MISA.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.API.Controllers
{
    /// <summary>
    /// Các api với nhóm khách hàng
    /// </summary>
    
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(IBaseService<CustomerGroup> baseService):base(baseService)
        {

        }
        /// <summary>
        /// Lấy thông tin danh sách nhóm khách hàng
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult GetCustomerGroup()
        //{
        //    var customerGroupService = new CustomerGroupService();
        //    var customerGroups = customerGroupService.GetCustomerGroups().ToList();
        //    if (customerGroups.Count > 0)
        //    {
        //        return StatusCode(200, customerGroups);
        //    }
        //    else
        //    {
        //        return StatusCode(204, customerGroups);
        //    }
        //}
        ///// <summary>
        ///// Lấy thông tin nhóm khách hàng theo ID
        ///// </summary>
        ///// <param name="customerGroupId">Mã nhóm khách hàng</param>
        ///// <returns></returns>
        //[HttpGet("{customerGroupId}")]
        //public IActionResult GetCustomerGroup(Guid customerGroupId)
        //{
        //    var customerGroupService = new CustomerGroupService();
        //    var customerGroup = customerGroupService.GetCustomerGroupById(customerGroupId);
        //    if (customerGroup != null)
        //    {
        //        return StatusCode(200, customerGroup);
        //    }
        //    else
        //    {
        //        return StatusCode(204, customerGroup);
        //    }
        //}
        ///// <summary>
        ///// Thêm mới một nhóm khách hàng
        ///// </summary>
        ///// <param name="customerGroup">nhóm khách hàng</param>
        ///// <returns>Số nhóm khách hàng được thêm thành công</returns>
        //[HttpPost]
        //public IActionResult InsertCustomerGroup(CustomerGroup customerGroup)
        //{

        //    var customerGroupService = new CustomerGroupService();
        //    var rowAffect = customerGroupService.InsertCustomerGroup(customerGroup);
        //    if (rowAffect > 0)
        //    {
        //        return Created("Them nhom khach hang thanh cong", customerGroup);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}
    }
}