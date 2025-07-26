using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasheel.BLL.Models;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Intrefaces
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>> filter = null);
        Task CreateAsync(Student obj);
        Task EdeiteAsync(Student obj);
        Task DeleteAsync(Student obj);
        Task<IEnumerable<StudentVM>> GetAsync();
        Task<Student> GetByIdAsync(Expression<Func<Student, bool>> filter = null);


    }
}

