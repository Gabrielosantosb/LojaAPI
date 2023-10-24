using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WebApplication4.Model;
using WebApplication4.Model.Context;
using WebApplication4.Repository.Implementations;

namespace WebApplication4.Business.Implementations
{
    public class BooksServiceImplementation : IBooksBusiness
    {
        private readonly IBooksRepository _repository;

        public BooksServiceImplementation(IBooksRepository repository)
        {

            _repository = repository;

        }

        public Books Create(Books books)
        {
            return _repository.Create(books);
        }

        public Books Delete(long id)
        {
            return _repository.Delete(id);
        }

        public List<Books> DeleteAll()
        {
            return _repository.DeleteAll();
        }

        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Books Update(Books books)
        {
            return _repository.Update(books);
        }
    }



}

