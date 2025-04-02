using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Configurations;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models.StoredProcedures;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<V_Teacher_Subject> V_Teacher_Subjects { get; set; }

        public DbSet<StudentInfoResult> StudentInfoResults => Set<StudentInfoResult>();

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) {}

        // Stored Procedures DbSet
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());

            modelBuilder.Entity<V_Teacher_Subject>().HasNoKey().ToView("V_Teacher_Subject");
        }

        // Stored Procedures Methods
        public async Task<StudentInfoResult?> GetStudentByStudentNumberAsync(string studentNumber)
        {
            var result = this.Set<StudentInfoResult>()
                .FromSqlInterpolated($"EXEC GetStudentByStudentNumber @StudentNumber={studentNumber}")
                .AsEnumerable()
                .FirstOrDefault();

            return await Task.FromResult(result);
        }
    }
}
