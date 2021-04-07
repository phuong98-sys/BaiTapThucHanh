using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Models
{
    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Qualification>()
                .HasMany(e => e.EmployeeQualifications)
                .WithRequired(e => e.Qualification)
                .WillCascadeOnDelete(false);
        }
    }
}
