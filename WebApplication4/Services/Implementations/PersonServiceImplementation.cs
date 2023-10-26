using System.Collections.Generic;
using WebApplication4.Model;
using WebApplication4.Repository.Implementations;

namespace WebApplication4.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {

            _repository = repository;

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
        public Person FindById(long id)
        {
            //Aqui deveria ser regras de negocios
            return _repository.FindById(id);
        }
        public List<Person> FindAll()
        {
            //Aqui deveria ser regras de negocios
            return _repository.FindAll();
        }

        public List<Person> DeleteAll()
        {
            return _repository.DeleteAll();
        }



    }



}

