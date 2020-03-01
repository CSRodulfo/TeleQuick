using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeleQuick.IDataAccess.Repositories;

namespace TeleQuick.DataAcces.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        #region Fields

        protected readonly DbContext Context;
        public ApplicationDbContext appContext => (ApplicationDbContext)Context;

        #endregion

        public Repository(DbContext context)
        {
            Context = context;
        }

        #region Public Methods

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<int> Add(T entity)
        {
            // await Context.AddAsync(entity);
            await Context.Set<T>().AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            // In case AsNoTracking is used
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public Task<int> Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().CountAsync(predicate);

        #endregion

    }
}