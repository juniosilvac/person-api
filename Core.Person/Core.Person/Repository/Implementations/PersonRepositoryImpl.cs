using Core.Person.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Core.Person.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private readonly MySqlContext _context;

        public PersonRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }     

        public Model.Person Create(Model.Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if(result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Model.Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Model.Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Model.Person Update(Model.Person person)
        {           
            try
            {
                if (!Exist(person.Id)) return null;

                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public bool Exist(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }      
    }
}
