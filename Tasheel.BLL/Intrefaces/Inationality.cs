using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasheel.BLL.Models;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Intrefaces
{
    public interface Inationality
    {
      Task<IEnumerable<Nationality>> GetAllAsync();
      Task CreateAsync(Nationality obj);
      Task<Nationality> GetByIdAsync(int Id);
      Task EdeiteAsync(Nationality obj);
      Task DeleteAsync(Nationality obj);
      Task<Nationality> GetByNameAsync(string Name);

    }
}
