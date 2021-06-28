using Acme.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestAngular.Tasks.Configuration
{
    public class TaskEntityConfiguration
    {
        public const int TitleMaxLength = 256;
        public const int DescriptionMaxLengh = 64 * 1024;
        public static void Configure(EntityTypeBuilder<Task> entityBuilder)
        {
            entityBuilder.ToTable("Tasks");
            entityBuilder.Property(e => e.Title).IsRequired().HasMaxLength(TitleMaxLength);
            entityBuilder.Property(e => e.Description).HasMaxLength(DescriptionMaxLengh);
        }
    }
}
