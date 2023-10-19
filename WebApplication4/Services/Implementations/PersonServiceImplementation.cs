using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WebApplication4.Model;
using WebApplication4.Model.Context;

namespace WebApplication4.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {

            _context = context;

        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        //public Person Create(Person person)
        //{

        //    try
        //    {
        //        _context.Add(person);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return person;
        //}

        public Person Create(Person person)
        {

            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {

            if (!Exists(person.Id)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);
            if (result != null)
            {

                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        public Person Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
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

        public List<Person> DeleteAll()
        {
            var allPersons = _context.Persons.ToList();
            _context.Persons.RemoveRange(allPersons);
            _context.SaveChanges();
            return allPersons;
        }

    
        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }



}

