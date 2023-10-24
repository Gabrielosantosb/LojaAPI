using System.Collections.Generic;
using WebApplication4.Model;

namespace WebApplication4.Repository.Implementations

{
    public interface IBooksRepository
    {
        Books Create(Books books);
        Books FindById(long id);
        List<Books> FindAll();
        Books Update(Books books);
        Books Delete(long id);
        List<Books> DeleteAll();

        bool Exists (long id);

    }
}
