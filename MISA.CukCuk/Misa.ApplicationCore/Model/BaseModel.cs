using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.ApplicationCore.Model
{
    /// <summary>
    /// 
    /// CreatedBy: Nguyễn Thị Phượng
    /// CreatedDate:25/3/2021
    /// </summary>

    class BaseModel
    {

        /// <summary>
        /// Class để check bắt buộc nhập
        /// </summary>
        public class Required : Attribute
        {

        }
        /// <summary>
        ///Class để check  không được trùng dữ liệu
        /// </summary>
        public class Unique : Attribute
        {

        }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public string CreatedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public string ModifiedDate { get; set; }

    }
}
