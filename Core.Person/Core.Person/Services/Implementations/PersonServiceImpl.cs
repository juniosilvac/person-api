using System;
using System.Collections.Generic;
using System.Threading;

namespace Core.Person.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Model.Person Create(Model.Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Person> FindAll()
        {
            var persons = new List<Model.Person>();
            for(int  i = 0; i < 8; i++)
            {
                var person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Model.Person FindById(long id)
        {
            return new Model.Person
            {
                Id = IncrementAndGet(),
                FirstName = "Junio",
                LastName = "Silva",
                Address = "Centro",
                Gender = "Male"

            };
        }

        public Model.Person Update(Model.Person person)
        {
            return person;
        }

        public Model.Person MockPerson(int i)
        {
            return new Model.Person
            {
                Id = IncrementAndGet(),
                FirstName = "Junio" + i,
                LastName = "Silva" + i,
                Address = "Centro" + i,
                Gender = "Male"

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
