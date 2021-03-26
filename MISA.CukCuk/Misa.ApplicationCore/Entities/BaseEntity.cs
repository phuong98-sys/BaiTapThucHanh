using Misa.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.ApplicationCore.Entity
{

    /// <summary>
    /// Đặc điểm bắt buộc
    /// </summary>
    public class Required : Attribute
    {

    }
    /// <summary>
    /// Đặc điểm duy nhất
    /// </summary>
    public class Unique : Attribute
    {

    }
    /// <summary>
    /// Lớp cơ sở cho các model classes
    /// </summary>
    public class BaseEntity
    {
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}
