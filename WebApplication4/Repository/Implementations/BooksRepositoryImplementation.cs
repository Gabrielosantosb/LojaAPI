using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WebApplication4.Model;
using WebApplication4.Model.Context;

namespace WebApplication4.Repository.Implementations
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private MySQLContext _context;

        public BooksRepositoryImplementation(MySQLContext context)
        {

            _context = context;

        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }
        public Books FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id == id);
        }


        public Books Create(Books book)
        {

            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public Books Update(Books book)
        {

            if (!Exists(book.Id)) return null;
            var result = _context.Books.SingleOrDefault(p => p.Id == book.Id);
            if (result != null)
            {

                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        public Books Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                    return result; // Retorna o objeto deletado
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public List<Books> DeleteAll()
        {
            var allBooks = _context.Books.ToList();
            _context.Books.RemoveRange(allBooks);
            _context.SaveChanges();
            return allBooks;
        }

    
        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id == id);
        }
    }



}

