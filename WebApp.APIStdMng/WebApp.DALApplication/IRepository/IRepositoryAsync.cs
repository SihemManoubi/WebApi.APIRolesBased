using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DALApplication.IRepository
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByStringIdAsync(string id);

        Task UpdateAsync(T entity);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Entities { get; }

        Task<List<T>> GetAllEntityAsync();
        Task<List<T>> GetEntityWhereAsync(Expression<Func<T, bool>> predicate);

        Task DeleteEntityAsync(T entity);
        Task UpdateEntityAsync(T entity);

        //verification du doublon
        Task<bool> CheckChampEntity(Expression<Func<T, bool>> predicate);

    }
}

