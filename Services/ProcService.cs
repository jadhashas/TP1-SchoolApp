using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Data;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models.StoredProcedures;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Services.Interfaces;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services
{
    public class ProcService : IProcService
    {
        private readonly SchoolContext _context;

        public ProcService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<StudentInfoResult?> GetStudentByNumberAsync(string studentNumber)
        {
            return await _context.GetStudentByStudentNumberAsync(studentNumber);
        }
    }
}
