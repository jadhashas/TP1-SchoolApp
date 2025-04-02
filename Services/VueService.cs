using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Data;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models.Views;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services
{
    public class VueService : IVueService
    {
        private readonly SchoolContext _context;

        public VueService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<V_Teacher_Subject>> GetTeachersWithSubjectsAsync()
        {
            return await _context.V_Teacher_Subjects.ToListAsync();
        }
    }
}
