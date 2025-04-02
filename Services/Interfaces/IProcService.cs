using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models.StoredProcedures;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services.Interfaces
{
    public interface IProcService
    {
        Task<StudentInfoResult?> GetStudentByNumberAsync(string studentNumber);
    }
}
