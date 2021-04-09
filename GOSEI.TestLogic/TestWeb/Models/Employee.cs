namespace TestWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        private DateTime startDate = DateTime.Now;
        public Employee()
        {
            EmployeeQualifications = new HashSet<EmployeeQualification>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Note { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }

    }

}
