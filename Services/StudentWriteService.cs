using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services
{
    public class StudentWriteService
    {
        private readonly IRepository<Student> _repo;

        public StudentWriteService(IRepository<Student> repo)
        {
            _repo = repo;
        }

        public void AddStudent(Student student)
        {
            _repo.Add(student);
        }
    }
}
