using Loja.Services.Services.BooksServices.Models;
using System.Collections.Generic;

namespace Loja.Services.Services.BooksServices
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
