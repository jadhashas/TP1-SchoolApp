using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fomation_E_Challenge__.Net____TP1__My_First_DB.Repositories.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
