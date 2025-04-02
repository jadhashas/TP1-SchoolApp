using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Models;
using Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Services
{
    public class StudentWriteService
    {
        private readonly IRepository<Student> _repo;
        private readonly ILogger<StudentWriteService> _logger;

        public StudentWriteService(IRepository<Student> repo, ILogger<StudentWriteService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public void AddStudent(Student student)
        {
            _logger.LogInformation("📥 Tentative d'ajout de l'étudiant {StudentNumber}", student.StudentNumber);

            try
            {
                _repo.Add(student);
                _logger.LogInformation("✅ Étudiant {StudentNumber} ajouté avec succès", student.StudentNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Erreur lors de l'ajout de l'étudiant {StudentNumber}", student.StudentNumber);
                throw;
            }
        }
    }
}
