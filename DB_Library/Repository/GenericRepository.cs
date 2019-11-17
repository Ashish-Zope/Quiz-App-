using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DB_Library.Repository
{
   public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected QuizzesDbEntities context;
        protected DbSet<TEntity> dbSet;
        public GenericRepository(QuizzesDbEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual  Task<List<TEntity>> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query =  dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return  query.ToListAsync();
        }

        public virtual IQueryable<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual Task<TEntity> GetById(object id)
        {
            return    dbSet.FindAsync(id);
        }

        public virtual  Task<TEntity> GetFirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefaultAsync(filter);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}
