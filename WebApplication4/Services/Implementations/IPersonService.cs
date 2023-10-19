using System.Collections.Generic;
using WebApplication4.Model;

namespace WebApplication4.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        Person Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
        List<Person> DeleteAll();

    }
}
