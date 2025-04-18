using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Generic
{
    public interface IGenericRepositoury<T> where T : BaseClass
    {

        public int Add(T entity);
        public IEnumerable<T> GetAll(bool WithTracking = false);
        public T? GetById(int id);
        public int Remove(T entity);
        public int Update(T entity);

    }
}
