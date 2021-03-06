using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TopraqShop.Framework.Base.Domain
{
    public interface IRepository<in TKey, TEntity> where TEntity : class
    {
        TEntity GetBy(TKey id);
        List<TEntity> GetAll();
        List<TEntity> GetAllWithJoins<TProperty>(Expression<Func<TEntity, TProperty>> expression);
        void Create(TEntity entity);
        bool IsExists(Expression<Func<TEntity, bool>> expression);
        int Commit();
    }
}