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
    public interface ICard
    {
        Task<IEnumerable<Card>> GetAllAsync(Expression<Func<Card, bool>> filter = null);
        Task CreateAsync(Card obj);
        Task EdeiteAsync(Card obj);
        Task DeleteAsync(Card obj);
        Task<IEnumerable<CardVM>> GetAsync();
        Task<Card> GetByIdAsync(Expression<Func<Card, bool>> filter = null);

    }
}
