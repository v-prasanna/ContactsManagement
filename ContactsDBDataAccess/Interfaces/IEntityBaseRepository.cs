using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDBDataAccess.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class
    {
        IList<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
