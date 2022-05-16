using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models
{
    public interface IRepository<T> : IDisposable where T : Base, new()
    {
        ICollection<T> GetAll();

        Task<ICollection<T>> GetAllAsync();

        ICollection<T> GetAllOrderBy(SortBy<T> sortBy);

        T GetById(string id);

        Task<T> GetByIdAsync(string id);

        ICollection<T> Get(Expression<Func<T, bool>> predicate);

        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate);

        ICollection<T> GetOrderBy(Expression<Func<T, bool>> predicate, SortBy<T> sortBy);

        ICollection<T> GetByQuery(Query<T> query);

        int Count(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        void Insert(T entity);

        int InsertAndSave(T entity);

        Task<int> InsertAndSaveAsync(T entity);

        void Update(T entity);

        int UpdateAndSave(T entity);

        Task<int> UpdateAndSaveAsync(T entity);

        void Delete(T entity);

        int DeleteAndSave(T entity);

        Task<int> DeleteAndSaveAsync(T entity);

        void DeleteById(string id);

        Task DeleteByIdAsync(string id);

        int DeleteByIdAndSave(string id);

        Task<int> DeleteByIdAndSaveAsync(string id);

        void DeleteSeveral(Expression<Func<T, bool>> predicate);

        Task DeleteSeveralAsync(Expression<Func<T, bool>> predicate);

        int DeleteSeveralAndSave(Expression<Func<T, bool>> predicate);

        Task<int> DeleteSeveralAndSaveAsync(Expression<Func<T, bool>> predicate);

        int Save();

        Task<int> SaveAsync();
    }
}
