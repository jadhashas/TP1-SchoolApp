using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
