using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Models;
using Tasheel.DAL.Database;
using Tasheel.DAL.Entities;

namespace Tasheel.BLL.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly MyContext db;
        public StudentRepo(MyContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Student obj)
        {
          
            await db.students.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task EdeiteAsync(Student obj)
        {
           db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>> filter = null)
        {
            if (filter == null)
                return await db.students.Include(s => s.nationality).ToListAsync();
            else
                return await db.students.Include(s=>s.nationality).Where(filter).ToListAsync();
        }
        public async Task<IEnumerable<StudentVM>> GetAsync()
        {
            var data = await db.students.Select(a => new StudentVM
            {
                Id = a.Id,
               FullName= a.FullName,
                Code = a.Code,
            }).ToListAsync();

            return data;
        }
        public async Task<Student> GetByIdAsync(Expression<Func<Student, bool>> filter)
        {
          
            var data = await db.students.Where(filter).Include(s => s.nationality).FirstOrDefaultAsync();
            return data;
        }


        //public async Task  Details(int id) 
        //  {

        //      db.Entry(id).State = EntityState.Deleted;
        //      await db.SaveChangesAsync();




        //  }
    }
    }
