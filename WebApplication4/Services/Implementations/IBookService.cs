using System.Collections.Generic;
using WebApplication4.Data.VO;


namespace WebApplication4.Business
{
    public interface IBookService
    {
        BooksVO Create(BooksVO books);
        BooksVO Update(BooksVO books);
        void Delete(long id);
        BooksVO FindById(long id);
        List<BooksVO> FindAll();
        List<BooksVO> DeleteAll();

    }
}
