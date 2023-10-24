using System.Collections.Generic;
using WebApplication4.Model;

namespace WebApplication4.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books books);
        Books Update(Books books);
        Books Delete(long id);
        Books FindById(long id);
        List<Books> FindAll();
        List<Books> DeleteAll();

    }
}
