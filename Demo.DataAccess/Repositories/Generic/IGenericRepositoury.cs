using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Generic
{
    public interface IGenericRepositoury<T> where T : BaseClass
    {

        public int Add(T entity);
        public IEnumerable<T> GetAll(bool WithTracking = false);
        public IEnumerable<T> GetAll(Expression<Func<T , bool>> Predicate);
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector);
        public T? GetById(int id);
        public int Remove(T entity);
        public int Update(T entity);

        IEnumerable<T> GetEnumerable();

        IQueryable<T> GetQuerable();


    }

    //public class Exception<T>
    //{
    //}
}
