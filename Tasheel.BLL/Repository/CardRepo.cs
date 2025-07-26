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
    public class CardRepo : ICard

    {
        private readonly MyContext db;
        public CardRepo(MyContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Card obj)
        {
            await db.cards.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Card obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task EdeiteAsync(Card obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Card>> GetAllAsync(Expression<Func<Card, bool>> filter = null)
        {
            if (filter == null)
                return await db.cards
                    .Include(s => s.academicYear)
                    .Include(s => s.student)
                    .ToListAsync();
            else
                return await db.cards
                    .Include(s => s.academicYear)
                    .Include(s => s.student)
                    .Where(filter)
                    .ToListAsync();
        }

        public async Task<IEnumerable<CardVM>> GetAsync()
        {
            var data = await db.cards.Select(a => new CardVM
            {
                Id= a.Id,
                AcademicClass = a.AcademicClass,
                Education = a.Education,
                GuardianName=a.GuardianName,
            }).ToListAsync();

            return data;
        }

        public async Task<Card> GetByIdAsync(Expression<Func<Card, bool>> filter = null)
        {
            var data = await db.cards.Where(filter)
                .Include(s => s.academicYear)
                .Include(s => s.student)
                .FirstOrDefaultAsync();
            return data;
        }
    }
}
