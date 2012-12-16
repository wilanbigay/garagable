using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Garagable.Model;

namespace Garagable.Data {

    public abstract class EFRepository<TEntity, TContext>  
        where TEntity : class
        where TContext : DbContext, new() {

       private TContext _dataContext;
        protected readonly IDbSet<TEntity> DbSet;

        protected EFRepository(IDatabaseFactory<TContext> databaseFactory) {

            if (databaseFactory == null)
                throw new ArgumentNullException("databaseFactory");

            DatabaseFactory = databaseFactory;
            DbSet = DataContext.Set<TEntity>();
        }

        protected IDatabaseFactory<TContext> DatabaseFactory {
            get;
            private set;
        }

        protected TContext DataContext {
            get {
                return _dataContext ?? (_dataContext = DatabaseFactory.Get());
            }
        }
        public virtual void Add(TEntity entity) {
            DbEntityEntry dbEntityEntry = DataContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached) {
                dbEntityEntry.State = EntityState.Added;
            } else {
                DbSet.Add(entity);
            }

        }

        public virtual void Update(TEntity entity) {
            DbEntityEntry dbEntityEntry = DataContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity) {
            var dbEntityEntry = DataContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted) {
                dbEntityEntry.State = EntityState.Deleted;
            } else {
                DbSet.Attach(entity); // make EF monitor the state of this entity
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where) {
            IEnumerable<TEntity> objects = DbSet.Where<TEntity>(where).AsEnumerable();
            foreach (TEntity entity in objects)
                Delete(entity);
        }

        public virtual void Delete(int id) {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public virtual TEntity GetById(int id) {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll() {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where) {
            return DbSet.Where(where);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where) {
            return DbSet.Where(where).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> ExcecuteSp(string spName, params object[] parameters) {
            var t = DataContext.Database.SqlQuery<TEntity>(spName, parameters);
            return t.AsQueryable();
        }

    }

}
