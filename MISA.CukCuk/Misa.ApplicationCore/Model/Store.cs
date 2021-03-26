using Misa.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Misa.ApplicationCore.Model
{
    /// <summary>
    /// Thông tin cửa hàng
    /// CreatedBy: Nguyễn Thị Phượng
    /// Ngày: 25/3/2021
    /// </summary>
    public class Store:BaseEntity
    {
        #region Constructure
        /// <summary>
        /// Hàm khởi tạo giá trị khóa chính cho cửa hàng
        /// CreatedBy: Nguyễn Thị Phượng
        /// CreatedDate:25/3/2021
        /// </summary>
        public Store()
        {
            this.StoreId = Guid.NewGuid();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Khóa chính bảng cửa hàng
        /// </summary>
        public Guid? StoreId { get; set; }
        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        [Unique]
        [Required]
        [DisplayName("Mã cửa hàng")]
        public string StoreCode { get; set; }
        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        [Required]
        [DisplayName("Tên cửa hàng")]
        public string StoreName { get; set; }
        /// <summary>
        /// Địac chỉ
        /// </summary>
        [Required]
        [Unique]
        [DisplayName("Địa chỉ cửa hàng")]
        public string StoreAddress { get; set; }
        /// <summary>
        /// Số điện thoại cửa hàng
        /// </summary>
        public string StorePhoneNumber { get; set; }
        /// <summary>
        /// Trạng thái hoạt động của cửa hàng
        /// </summary>
        public String StatusStore { get; set; }
        /// <summary>
        /// Mã số thuế của cửa hàng
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// Khóa chính từ bảng đơn vị hành chính, để lấy thông tin địa chỉ của cửa hàng
        /// </summary>
       
        public Guid? AdministrativeUnitId { get; set; }

        #endregion
    }
}
