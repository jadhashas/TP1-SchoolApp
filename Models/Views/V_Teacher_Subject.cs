using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Models.Views
{
    public class V_Teacher_Subject
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
    }
}
