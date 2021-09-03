using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _01_Framework.Domain
{
    public interface IGenericRepository<TEntity, in TKey> where TEntity : EntityBase
    {
        // List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null,
        //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        //     Expression<Func<TEntity, IProperty>> includes = null);

        List<TEntity> GetAll(Func<TEntity, object> select);
        TEntity GetBy(TKey entity);
        bool Exists(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        void SaveChange();
    }
}