
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Threading.Tasks;
namespace Misa.ApplicationCore.Model
{

    /// <summary>
    /// Thông tin kh
    /// CreatedBy: Nguyễn Thị Phượng
    /// CreatedDate:25/3/2021
    /// </summary>
    public class Customer:BaseEntity
    {
        #region Declare
        static List<Customer> ListCustomer = new List<Customer>()
        {
        };
        #endregion
        #region Costructor
        /// <summary>
        /// Khởi tạo không tham số, luôn khởi tạo ra ID cho khách hàng
        /// </summary>
        public Customer()
        {
            this.CustomerId = Guid.NewGuid();
        }
        /// <summary>
        /// ID khách hàng
        /// </summary>
        /// <param name="CustomerCode">Mã khách hàng</param>
        /// <param name="FullName">Tên</param>
        public Customer(string CustomerCode, String FullName)
        {
            this.CustomerId = Guid.NewGuid();
            this.CustomerCode = CustomerCode;
            this.FullName = FullName;

        }
        #endregion
        #region properties
        /// <summary>
        /// Mã kh
        /// </summary>
        //[PrimaryKey]
        public Guid? CustomerId { get; set; }
        /// <summary>
        /// Mã kh
        /// </summary>
      [Required]
      //[CheckDuplicate]
        [DisplayName("Mã khách hàng")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên khách hàng
        /// </summary>
        [DisplayName("Tên khách hàng")]
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Gới tính(0 - Nữ , 1- Nam, 2- khác)
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Khóa ngoại từ bảng nhóm khác hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        [Required]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }

        #region Method
        #endregion
        #region Others
        #endregion
    }
    #endregion

}