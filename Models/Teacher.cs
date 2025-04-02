using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Models
{
    internal class Teacher
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        [Required]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
