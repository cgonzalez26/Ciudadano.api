using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ciudadano.Api.Models
{
    public class Repository<T> : IRepository<T> where T : Base, new()
    {
        public readonly ApplicationDbContext Context;
        private bool _disposed = false;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICollection<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public ICollection<T> GetAllOrderBy(SortBy<T> sortBy)
        {
            if (sortBy.OrderBy == null && sortBy.OrderByDescending == null)
            {
                return Context.Set<T>().OrderBy(e => e.InsertedAt).ToList();
            }

            if (sortBy.OrderBy != null)
            {
                return Context.Set<T>().OrderBy(sortBy.OrderBy).ToList();
            }

            return Context.Set<T>().OrderByDescending(sortBy.OrderByDescending).ToList();
        }

        public T GetById(string id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id.Equals(id));
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public ICollection<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public ICollection<T> GetOrderBy(Expression<Func<T, bool>> predicate, SortBy<T> sortBy)
        {
            Expression<Func<T, bool>> whereTrue = e => true;
            var where = predicate ?? whereTrue;

            if (sortBy.OrderBy == null && sortBy.OrderByDescending == null)
            {
                return Context.Set<T>().Where(where).OrderBy(e => e.InsertedAt).ToList();
            }

            if (sortBy.OrderBy != null)
            {
                return Context.Set<T>().Where(where).OrderBy(sortBy.OrderBy).ToList();
            }

            return Context.Set<T>().Where(where).OrderByDescending(sortBy.OrderByDescending).ToList();
        }

        public ICollection<T> GetByQuery(Query<T> query)
        {
            if (query.Page < 0) return new List<T>();

            Expression<Func<T, bool>> whereTrue = e => true;
            var where = query.Where ?? whereTrue;

            if (query.OrderBy == null && query.OrderByDescending == null)
            {
                return Context.Set<T>().Where(where).OrderBy(e => e.InsertedAt)
                    .Skip(query.Page * query.Top)
                    .Take(query.Top)
                    .ToList();
            }

            if (query.OrderBy != null)
            {
                return Context.Set<T>().Where(where).OrderBy(query.OrderBy)
                    .Skip(query.Page * query.Top)
                    .Take(query.Top)
                    .ToList();
            }

            return Context.Set<T>().Where(where).OrderByDescending(query.OrderByDescending)
                .Skip(query.Page * query.Top)
                .Take(query.Top)
                .ToList();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            var where = predicate ?? (e => true);
            return Context.Set<T>().Count(where);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            var where = predicate ?? (e => true);
            return await Context.Set<T>().CountAsync(where);
        }

        public void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public int InsertAndSave(T entity)
        {
            Insert(entity);
            return Save();
        }

        public async Task<int> InsertAndSaveAsync(T entity)
        {
            Insert(entity);
            return await SaveAsync();
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public int UpdateAndSave(T entity)
        {
            Update(entity);
            return Save();
        }

        public async Task<int> UpdateAndSaveAsync(T entity)
        {
            Update(entity);
            return await SaveAsync();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public int DeleteAndSave(T entity)
        {
            Delete(entity);
            return Save();
        }

        public async Task<int> DeleteAndSaveAsync(T entity)
        {
            Delete(entity);
            return await SaveAsync();
        }

        public void DeleteById(string id)
        {
            var entity = GetById(id);
            Context.Set<T>().Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            Context.Set<T>().Remove(entity);
        }

        public int DeleteByIdAndSave(string id)
        {
            DeleteById(id);
            return Save();
        }

        public async Task<int> DeleteByIdAndSaveAsync(string id)
        {
            await DeleteByIdAsync(id);
            return await SaveAsync();
        }

        public void DeleteSeveral(Expression<Func<T, bool>> predicate)
        {
            var entities = Get(predicate);
            Context.Set<T>().RemoveRange(entities);
        }

        public async Task DeleteSeveralAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await GetAsync(predicate);
            Context.Set<T>().RemoveRange(entities);
        }

        public int DeleteSeveralAndSave(Expression<Func<T, bool>> predicate)
        {
            DeleteSeveral(predicate);
            return Save();
        }

        public async Task<int> DeleteSeveralAndSaveAsync(Expression<Func<T, bool>> predicate)
        {
            await DeleteSeveralAsync(predicate);
            return await SaveAsync();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
