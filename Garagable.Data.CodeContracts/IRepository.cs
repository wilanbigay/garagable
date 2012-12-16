using System;
using System.Linq;
using System.Linq.Expressions;

namespace Garagable.Data.CodeContracts {
    public interface IRepository<TEntity> where TEntity : class {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        void Delete(int id);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> ExcecuteSp(string spName, params object[] parameters);
    }
}