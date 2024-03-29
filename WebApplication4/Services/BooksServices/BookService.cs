﻿using System.Collections.Generic;
using System.Linq;
using WebApplication4.ORM.Entity;
using WebApplication4.ORM.Repository.Base;
using WebApplication4.Services.BooksServices.Models;

namespace WebApplication4.Services.BooksServices
{
    public class BookService : IBookService
    {
        private readonly IRepository<Books> _repository;
        private readonly BooksConverter _converter;


        public BookService(IRepository<Books> repository)
        {

            _repository = repository;
            _converter = new BooksConverter();

        }

        public BooksVO Create(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            booksEntity = _repository.Create(booksEntity);
            return _converter.Parse(booksEntity);
        }
        public BooksVO Update(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            booksEntity = _repository.Update(booksEntity);
            return _converter.Parse(booksEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public BooksVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public List<BooksVO> DeleteAll()
        {
            return _converter.Parse(_repository.DeleteAll());
        }



    }



}

