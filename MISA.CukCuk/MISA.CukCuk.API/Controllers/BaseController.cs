using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.ApplicationCore;
using Misa.ApplicationCore.Entities;
using Misa.ApplicationCore.Enums;
using Misa.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        IBaseService<MISAEntity> _baseService;
        ServiceResult serviceResult;
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            this._baseService = baseService;
            this.serviceResult = new ServiceResult();
        }
        /// <summary>
        /// Lấy thông tin danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {

            var entities = _baseService.GetAll().ToList();
            if (entities.Count > 0)
            {
                return StatusCode(200, entities);
            }
            else
            {
                return StatusCode(204, entities);
            }
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo ID
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {

            var entity = _baseService.GetObjectById(entityId);
            if (entity != null)
            {
                return StatusCode(200, entity);
            }
            else
            {
                return StatusCode(204, entity);
            }
        }
        /// <summary>
        /// Thêm mới một khách hàng
        /// </summary>
        /// <param name="customer">Thông tin 1 khách hàng</param>
        /// <returns>Số khách hàng được thêm thành công</returns>
        [HttpPost]
        public IActionResult Insert(MISAEntity entity)
        {

            try
            {
               
                var serviceResult = _baseService.InsertObject(entity)  ;

                if (serviceResult.MISACode == MisaCode.Susscess)
                {
                    return Created("Thêm khách hàng mới thành công", entity);
                }
                else if (serviceResult.MISACode == MisaCode.NotValid || serviceResult.MISACode == MisaCode.IsEmpty)
                {
                    return StatusCode(400, serviceResult.Msg);
                }
                else
                {
                    return NoContent();
                }
                //var messages = "";
                //foreach (var mess in listError)
                //{
                //    messages += mess + "\n";
                //}

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    devMsg = new { msg = "Lỗi server khi thêm" },
                    userMsg = ex.Message,

                    code = 500
                }) ;

            }
        }
        [HttpPut]
        public IActionResult Update(MISAEntity entity)
        {

            try
            {
                serviceResult = _baseService.UpdateObject(entity);

                if (serviceResult.MISACode == MisaCode.Susscess)
                {
                    return Created("Sửa khách hàng mới thành công", entity);
                }
                else if (serviceResult.MISACode == MisaCode.NotValid || serviceResult.MISACode == MisaCode.IsEmpty)
                {
                    return StatusCode(400, serviceResult.Msg);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    devMsg = new { msg = "Lỗi server khi sửa" },
                    userMsg = ex.Message,

                    code = 500
                });

            }
        }
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var rowAffect = _baseService.DeleteObject(entityId);
            try
            {
                if (rowAffect <= 0)
                {
                    return BadRequest(400);
                }
                else
                {
                    return StatusCode(200, "Thanh cong");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    devMsg = new { msg = "Lỗi server, không xóa được" },
                    userMsg = ex.Message,

                    code = "500"
                });

            }
        }
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
