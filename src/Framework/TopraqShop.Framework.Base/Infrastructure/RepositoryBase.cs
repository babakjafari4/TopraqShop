using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TopraqShop.Framework.Base.Domain;

namespace TopraqShop.Framework.Base.Infrastructure
{
    public class RepositoryBase<TKey, TEntity>:IRepository<TKey, TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity GetBy(TKey id)
        {
            return _dbContext.Find<TEntity>(id);
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAllWithJoins<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            return _dbContext.Set<TEntity>().Include(expression).ToList();
        }

        public void Create(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        public bool IsExists(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Any(expression);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}