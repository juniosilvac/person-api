using Core.Person.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Person.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }     

        public Model.Person Create(Model.Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Model.Person> FindAll()
        {
           return _repository.FindAll();
        }

        public Model.Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Model.Person Update(Model.Person person)
        {  
            return _repository.Update(person);
        }      
    }
}
