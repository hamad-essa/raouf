using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasheel.BLL.Models;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Intrefaces
{
    public interface Iacademicyear
    {
        Task<IEnumerable<AcademicYear>> GetAllAsync();
        Task CreateAsync(AcademicYear obj);
        Task<AcademicYear> GetByIdAsync(int Id);
        Task EdeiteAsync(AcademicYear obj);
        Task DeleteAsync(AcademicYear obj);
        Task<AcademicYear> GetByYearAsync(string year);
    }
}
