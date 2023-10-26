using Loja.Services.Services.PersonServices.Models;
using System.Collections.Generic;

namespace Loja.Services.Services.PersonServices
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> DeleteAll();

    }
}
