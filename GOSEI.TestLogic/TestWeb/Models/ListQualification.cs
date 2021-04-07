namespace TestWeb.Models
{
    using global::TestWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListQualification")]
    public partial class ListQualification
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public int QualificationId { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Institution { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidTo { get; set; }

        public string Note { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Qualification Qualification { get; set; }
    }
}
