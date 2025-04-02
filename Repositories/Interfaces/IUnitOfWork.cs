using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
        IRepository<Person> Persons { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Class> Classes { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Enrollment> Enrollments { get; }

        Task<int> CompleteAsync();
    }
}
