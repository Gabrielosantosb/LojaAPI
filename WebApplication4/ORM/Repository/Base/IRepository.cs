

using System.Collections.Generic;
using WebApplication4.ORM.Entity;

namespace WebApplication4.ORM.Repository.Base

{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T Delete(long id);

        T FindById(long id);
        List<T> FindAll();
        List<T> DeleteAll();

        bool Exists(long id);
    }
}
