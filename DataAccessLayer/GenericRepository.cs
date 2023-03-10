using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace hangmanV1.DataAccessLayer

{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
        internal WordDbContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(WordDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {

            try
            {
                if (context.Entry(entityToDelete).State.Equals(EntityState.Detached))
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }
            catch(Exception ex) 
            {
                Console.WriteLine("entity cannot be null, check the ID");

            }
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }

        Task<TEntity> IGenericRepository<TEntity>.GetByID(object id)
            {
            throw new NotImplementedException();
            }

        public void InsertAsync(TEntity entity)
            {
            throw new NotImplementedException();
            }
        }
}