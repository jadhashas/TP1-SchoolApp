using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Data;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repository;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public IRepository<Student> Students { get; private set; }
        public IRepository<Person> Persons { get; private set; }
        public IRepository<Teacher> Teachers { get; private set; }
        public IRepository<Class> Classes { get; private set; }
        public IRepository<Subject> Subjects { get; private set; }
        public IRepository<Enrollment> Enrollments { get; private set; }

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            Students = new Repository<Student>(_context);
            Persons = new Repository<Person>(_context);
            Teachers = new Repository<Teacher>(_context);
            Classes = new Repository<Class>(_context);
            Subjects = new Repository<Subject>(_context);
            Enrollments = new Repository<Enrollment>(_context);
        }

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();
    }
}
