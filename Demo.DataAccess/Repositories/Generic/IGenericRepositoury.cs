using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Generic
{
    public interface IGenericRepositoury<T> where T : BaseClass
    {

        public int Add(T entity);
        public IEnumerable<T> GetAll(bool WithTracking = false);
        //public IEnumerable<TResult> GetAll<TResult>(Exception<Func<T, TResult>> selector);
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
