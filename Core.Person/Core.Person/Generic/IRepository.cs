using Core.Person.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Person.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);

        T FindById(long id);

        List<T> FindAll();

        T Update(T entity);

        void Delete(long id);

        bool Exist(long id);
    }
}
