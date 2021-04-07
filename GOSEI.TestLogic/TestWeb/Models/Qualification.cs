namespace TestWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Qualification")]
    public partial class Qualification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Qualification()
        {
            EmployeeQualifications = new HashSet<EmployeeQualification>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; }
    }
}
