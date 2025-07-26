using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.DAL.Database;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Repository
{
    public class NationalityRepo : Inationality
    {
        private readonly MyContext db;
        public NationalityRepo(MyContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Nationality obj)
        {
            
            await db.nationalities.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Nationality obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task EdeiteAsync(Nationality obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nationality>> GetAllAsync()
        {
            var data = await db.nationalities.ToListAsync();
          
            return data;
        }

        public async Task<Nationality> GetByIdAsync(int Id)
        {
            var data = await db.nationalities.Where(a => a.Id == Id).FirstOrDefaultAsync();

            return data;
        }
        public async Task<Nationality> GetByNameAsync(string Name)
        {
            return await db.nationalities.FirstOrDefaultAsync(a => a.Name == Name);
        }

    }
}

