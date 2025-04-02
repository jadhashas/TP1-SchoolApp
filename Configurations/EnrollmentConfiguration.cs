using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            // Empêche la suppression en cascade sur Student
            builder.HasOne(e => e.Student)
                   .WithMany()
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Empêche la suppression en cascade sur Class
            builder.HasOne(e => e.Class)
                   .WithMany()
                   .HasForeignKey(e => e.ClassId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
