using System.Collections.Generic;
using System.Linq;
using WebApplication4.Data.Converter.Implementations;
using WebApplication4.Data.VO;
using WebApplication4.Model;
using WebApplication4.Repository.Implementations;

namespace WebApplication4.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {

            _repository = repository;
            _converter = new PersonConverter();

        }

        public PersonVO Create(PersonVO person)
        {
            //Aqui deveria ser regras de negocios
            //return _repository.Create(person);
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            //Aqui deveria ser regras de negocios
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            
            _repository.Delete(id);
        }
        public PersonVO FindById(long id)
        {
            //Aqui deveria ser regras de negocios
            return _converter.Parse(_repository.FindById(id));
        }
        public List<PersonVO> FindAll()
        {
            //Aqui deveria ser regras de negocios
            return _converter.Parse(_repository.FindAll());
        }

        public List<PersonVO> DeleteAll()
        {
            return _converter.Parse(_repository.DeleteAll());
        }



    }



}

