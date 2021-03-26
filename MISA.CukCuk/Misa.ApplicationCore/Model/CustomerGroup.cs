using Misa.ApplicationCore.Entity;
using Misa.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Model
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// </summary>
    public class CustomerGroup:BaseEntity
    {
        /// <summary>
        /// Khởi tạo không tham số, khởi tạo Id nhóm khách hàng
        /// </summary>
        public CustomerGroup()
        {
            this.CustomerGroupId = Guid.NewGuid();
        }
        /// <summary>
        /// khởi tạo có tham số
        /// </summary>
        /// <param name="customerGroupName">Tên nhóm khách hàng</param>
        public CustomerGroup(string customerGroupName)
        {
            this.CustomerGroupId = Guid.NewGuid();
            this.CustomerGroupName = customerGroupName;
            this.ParentId = Guid.NewGuid();
        }

        /// <summary>
        /// Khóa chính Bảng nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        ///// <summary>
        ///// Khóa chính cha nhóm khách hàng
        ///// </summary>
        public Guid? ParentId { get; set; }

    }
}