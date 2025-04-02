using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services
{
    public class StudentReadService
    {
        private readonly IReadOnlyRepository<Student> _repo;
        private readonly ILogger<StudentReadService> _logger;

        public StudentReadService(IReadOnlyRepository<Student> repo, ILogger<StudentReadService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public void ShowAllStudents()
        {
            _logger.LogInformation("Showing all students");
            var students = _repo.GetAll();
            foreach (var s in students)
                Console.WriteLine(s.StudentNumber);

            _logger.LogInformation("Finished showing all students");
        }
    }
}
