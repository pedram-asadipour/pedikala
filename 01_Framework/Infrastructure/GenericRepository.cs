using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : EntityBase
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> GetAll(Func<TEntity, object> select)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (select != null)
                query.Select(select);

            return query.ToList();
        }

        public TEntity GetBy(TKey entity)
        {
            return _dbContext.Find<TEntity>(entity);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Any(expression);
        }

        public void Create(TEntity entity)
        {
            _dbContext.Add<TEntity>(entity);
        }

        public void Edit(TEntity entity)
        {
            _dbContext.Update<TEntity>(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Remove<TEntity>(entity);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}