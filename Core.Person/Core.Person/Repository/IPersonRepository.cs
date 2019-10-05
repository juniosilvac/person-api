using Core.Person.Model;
using System.Collections.Generic;

namespace Core.Person.Repository
{
    public interface IPersonRepository
    {
        Model.Person Create(Model.Person person);

        Model.Person FindById(long id);

        List<Model.Person> FindAll();

        Model.Person Update(Model.Person person);

        void Delete(long id);

        bool Exist(long id);
    }
}
