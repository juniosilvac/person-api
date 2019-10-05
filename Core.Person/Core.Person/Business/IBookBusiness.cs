using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Person.Business
{
    public interface IBookBusiness
    {
        Model.Book Create(Model.Book book);

        Model.Book FindById(long id);

        List<Model.Book> FindAll();

        Model.Book Update(Model.Book book);

        void Delete(long id);

        bool Exist(long id);
    }
}
