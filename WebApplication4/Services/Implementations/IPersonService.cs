using System.Collections.Generic;
using WebApplication4.Data.VO;


namespace WebApplication4.Business
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
