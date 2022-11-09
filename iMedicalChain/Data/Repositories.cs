using iMedicalChain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iMedicalChain.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDataContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        private const int PAGE_COUNT = 20;

        public Repository(AppDataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> AddListAsync(IList<T> entity)
        {
            foreach (var item in entity)
            {
                item.createdAt = DateTime.Now;
            }
            await _dbSet.AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public IQueryable<T> GetAllByExp(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query.Where(predicate);
        }
        public async Task UpdateAsync(T entity, bool disableTracking = true)
        {
            try
            {
                IQueryable<T> query = _dbContext.Set<T>();
                if (disableTracking)
                {
                    query = query.AsNoTracking();
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    _dbContext.Set<T>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            //   _dbContext.Entry(entity).State = EntityState.Modified;

        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdIncAsync(int id, string[] includeTables = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            return await query.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            query = query.Where(predicate);
            return orderBy(query);
        }

        public IQueryable<T> GetAllByInc(string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            return query;
        }

        public IQueryable<T> GetAllByExpInc(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            return query.Where(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query.Where(predicate);
        }

        public IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            query = query.Where(predicate);
            return orderBy(query);
        }

        public IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var includeTable in includeTables)
            {
                query = query.Include(includeTable);
            }

            query = query.Where(predicate);

            if (page > 1) query = query.Skip(page * PAGE_COUNT);

            query = query.Take(PAGE_COUNT);

            return orderBy(query);
        }

        public IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            query = query.Where(predicate);

            if (page > 1) query = query.Skip(page * PAGE_COUNT);

            query = query.Take(PAGE_COUNT);

            return orderBy(query);
        }

        public IQueryable<T> GetAll(bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public void DeleteDb()
        {
            _dbContext.Database.EnsureDeleted();
        }

       

        public async Task UpdateListSync(IList<T> entity, bool disableTracking = true)
        {
            try
            {
                IQueryable<T> query = _dbContext.Set<T>();

                if (disableTracking)
                {
                    query = query.AsNoTracking();

                    foreach (var item in entity)
                    {
                        if (_dbContext.Set<T>().FirstOrDefault(a => a.Id == item.Id) is null)
                        {
                            _dbContext.Add(item);
                        }
                        else
                        {
                            _dbContext.Update(item);
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch
            {

            }
        }

        public async Task<T> GetOne(bool disableTracking = true)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync();
        }
    }
    public interface IRepository<T> where T : Entity
    {

      
        Task UpdateListSync(IList<T> entity, bool disableTracking = true);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity, bool disableTracking = true);
        Task DeleteAsync(T entity);
        Task<IList<T>> AddListAsync(IList<T> entity);
        Task<T> GetOne(bool disableTracking = true);
        Task<T> GetByIdAsync(int id, bool disableTracking = true);
        Task<T> GetByIdIncAsync(int id, string[] includeTables, bool disableTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByInc(string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByExpInc(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool disableTracking = true);
        IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
        IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
        IQueryable<T> GetAll(bool disableTracking = true);
        IQueryable<T> GetAllByExp(Expression<Func<T, bool>> predicate, bool disableTracking = true);
        void DeleteDb();
    }
}
