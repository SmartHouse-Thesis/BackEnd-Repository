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
        private AppDbContext dbContext;

        private AppDbContext _dbContext { get; set; }
        private ILogger<BaseRepo<T>> _logger { get; set; }
        
        public BaseRepo(AppDbContext dbContext, ILogger<BaseRepo<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public BaseRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> FindAll(List<string> includes = null)
        {
            try
            {
                IQueryable<T> items = _dbContext.Set<T>().AsNoTracking();

                if (includes != null && includes.Any())
                {
                    includes.Where(i => i != null).ToList().ForEach(i => { items = items.Include(i); });
                }

                return items;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} FindAll function error", typeof(BaseRepo<T>));
                return null;
            }
        }

        public T Get(Guid id)
        {
            try
            {
                T items = _dbContext.Set<T>().Find(id);
                return items;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Get function error", typeof(BaseRepo<T>));
                return null;
            }
        }

        public void Add(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Add function error", typeof(BaseRepo<T>));
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(BaseRepo<T>));
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Remove function error", typeof(BaseRepo<T>));
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
