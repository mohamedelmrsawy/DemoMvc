using Demo.DataAccess.Data.Contexts;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Generic
{
    public class GenericRepository<T>(ApplicationDbContext _dbContext) : IGenericRepositoury<T> where T : BaseClass
    {
        public IEnumerable<T> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Set<T>().ToList();
            }
            else
            {
                return _dbContext.Set<T>().AsNoTracking().ToList();
            }

        }


        public T? GetById(int id)
        {
             
            return _dbContext.Set<T>().Find(id);
        }



        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }


        public int Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }


        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetEnumerable()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> GetQuerable()
        {
            return _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Predicate)
        {
            return _dbContext.Set<T>().Where(Predicate).ToList();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector)
        {
            return _dbContext.Set<T>().Where(e => e.InDeleted != true).Select(selector);
        }

    }
}

