using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.ApplicationCore.Model
{
    /// <summary>
    /// Thông tin đơn vị hành chính
    /// CreatedBy: Nguyễn Thị Phượng
    /// Ngày: 25/3/2021
    /// </summary>
    class AdministrativeUnit
    {
    
        #region constructor
       /// <summary>
       /// Hàm khởi tạo giá tyrtij cho khóa chính của đơn vị hành chính
       /// </summary>
        public AdministrativeUnit()
        {
            this.AdministrativeUnitId = Guid.NewGuid();
        }
        #endregion
        #region Properties
         /// <summary>
         /// Khóa chính của đoen vị hành chính
         /// </summary>
        public Guid? AdministrativeUnitId { get; set; }
        /// <summary>
        /// Mã đơn vị hành chính
        /// </summary>
        public string AdministrativeUnitCode { get; set; }
     
        /// <summary>
        /// Kiểu đơn vị hành chính:
        /// 0- Mã quốc gia
        /// 1- Mã tỉnh/ thành phố
        /// 2- Mã huyện/ Quận
        /// 3- Mã Phường/ Xã
        /// 4- Mã Phố
        /// </summary>
        public int? AdministrativeUnitType { get; set; }
        /// <summary>
        /// Tên đơn vị hành chính
        /// </summary>
        public string AdministrativeUnitName { get; set; }
        /// <summary>
        /// Mô tả cho đơn vị hành chính
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
