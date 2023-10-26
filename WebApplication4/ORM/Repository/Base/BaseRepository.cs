using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication4.ORM.Entity;

namespace WebApplication4.ORM.Repository.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private readonly DbSet<T> dataset;

        public BaseRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();

        }
        public T FindById(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            return result;
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public T Update(T item)
        {

            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            else
            {
                return null;
            }
        }

        public T Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id == id);
            if (result != null)
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            return null;

        }

        public List<T> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id == id);
        }


    }
}
