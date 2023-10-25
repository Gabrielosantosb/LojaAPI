

using System.Collections.Generic;
using WebApplication4.Model;
using WebApplication4.Model.Generic;

namespace WebApplication4.Repository.Implementations

{
    public interface IRepository<T> where T : BaseEntity     
    {
        T Create(T item);
        T Update(T item);
        T Delete(long id);

        T FindById(long id);
        List<T> FindAll();
        List<T> DeleteAll();

        bool Exists (long id);

    }
}
