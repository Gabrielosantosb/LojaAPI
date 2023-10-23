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
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {

            _repository = repository;

        }

        public List<Person> FindAll()
        {
            //Aqui deveria ser regras de negocios
            return _repository.FindAll();
        }
        public Person FindById(long id)
        {
            //Aqui deveria ser regras de negocios
            return _repository.FindById(id);
        }


        public Person Create(Person person)
        {
            //Aqui deveria ser regras de negocios
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            //Aqui deveria ser regras de negocios
            return _repository.Create(person);
        }

        public Person Delete(long id)
        {
            //Aqui deveria ser regras de negocios
            return _repository.Delete(id);
        }

        public List<Person> DeleteAll()
        {
            return _repository.DeleteAll();
        }



    }



}

