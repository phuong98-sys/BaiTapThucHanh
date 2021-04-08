namespace TestWeb.Models
{
    using global::TestWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeQualification")]
    public partial class EmployeeQualification
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public int QualificationId { get; set; }

        [Required]
        [StringLength(250)]
        public string Institution { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
     "{0:yyyy-MM-dd}",
      ApplyFormatInEditMode = true)]
        public DateTime ValidFrom { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
     "{0:yyyy-MM-dd}",
      ApplyFormatInEditMode = true)]
        public DateTime ValidTo { get; set; }

        public string Note { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Qualification Qualification { get; set; }
    }
}
