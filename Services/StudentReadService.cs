using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services
{
    public class StudentReadService
    {
        private readonly IReadOnlyRepository<Student> _repo;

        public StudentReadService(IReadOnlyRepository<Student> repo)
        {
            _repo = repo;
        }

        public void ShowAllStudents()
        {
            var students = _repo.GetAll();
            foreach (var s in students)
                Console.WriteLine(s.StudentNumber);
        }
    }
}
