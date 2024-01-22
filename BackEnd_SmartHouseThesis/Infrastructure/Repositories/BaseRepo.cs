using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<T>> _logger;

        public BaseRepo(AppDbContext dbContext, ILogger<BaseRepo<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public BaseRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<T>> FindAllAsync(List<string> includes = null)
        {
            try
            {
                IQueryable<T> items = _dbContext.Set<T>().AsNoTracking();

                if (includes != null && includes.Any())
                {
                    foreach (var include in includes.Where(i => i != null))
                    {
                        items = items.Include(include);
                    }
                }

                return items;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} FindAllAsync function error", typeof(BaseRepo<T>));
                return null;
            }
        }

        public async Task<T> GetAsync(Guid id)
        {
            try
            {
                T item = await _dbContext.Set<T>().FindAsync(id);
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAsync function error", typeof(BaseRepo<T>));
                return null;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} AddAsync function error", typeof(BaseRepo<T>));
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} UpdateAsync function error", typeof(BaseRepo<T>));
            }
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} RemoveAsync function error", typeof(BaseRepo<T>));
            }
        }

    /*
            //
            IQueryable<T> IBaseRepo<T>.FindAll(List<string> includes)
            {
                throw new NotImplementedException();
            }

            Task<int> IBaseRepo<T>.Add(T entity)
            {
                throw new NotImplementedException();
            }

            Task<int> IBaseRepo<T>.Update(T entity)
            {
                throw new NotImplementedException();
            }

            Task<int> IBaseRepo<T>.Remove(T entity)
            {
                throw new NotImplementedException();
            }*/
}
}
