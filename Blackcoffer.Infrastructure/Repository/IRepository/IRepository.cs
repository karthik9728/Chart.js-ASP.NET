using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blackcoffer.Infrastructure.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        IEnumerable<T> GetAll(Expression<Func<T,bool>>? filter = null);

        T Get(Expression<Func<T, bool>>? filter = null);

    }
}
