using RESTFulExample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTFulExample.DAL.Interfaces
{
    public interface IServiceRepository<T>: IDisposable where T : BaseServiceEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsynс(string id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> GetByAsync(Expression<Func<T, bool>> where = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> CountAsync(Expression<Func<T, bool>> where = null);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> where = null);
    }
}
