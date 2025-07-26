using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.DAL.Database;
using Tasheel.DAL.Entities;


namespace Tasheel.BLL.Repository
{
    public class AcademicYearRepo : Iacademicyear

    {
        private readonly MyContext db;
        public AcademicYearRepo (MyContext db)
            {
            this.db = db;
            }
       
        public async Task CreateAsync(AcademicYear obj)
        {
            
            await db.academicYears.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(AcademicYear obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task EdeiteAsync(AcademicYear obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AcademicYear>> GetAllAsync()
        {
            var data = await db.academicYears.ToListAsync();

            return data;
        }

        public async Task<AcademicYear> GetByIdAsync(int Id)
        {
            var data = await db.academicYears.Where(a => a.Id == Id).FirstOrDefaultAsync();

            return data;
        }

        public async Task<AcademicYear> GetByYearAsync(string year)
        {
            return await db.academicYears.FirstOrDefaultAsync(a => a.Year == year);
        }
        
    }
}
