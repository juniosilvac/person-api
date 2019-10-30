using Core.Person.Data.Converter;
using Core.Person.Data.VO;
using System.Collections.Generic;
using System.Linq;

namespace Core.Person.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Model.Person>, IParser<Model.Person, PersonVO>
    {
        public Model.Person Parse(PersonVO origin)
        {
            if (origin == null) return new Model.Person();
            return new Model.Person
            {
                Id = origin.Id.Value,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(Model.Person origin)
        {
            if (origin == null) return new PersonVO();
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Model.Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Model.Person>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Model.Person> origin)
        {
            if (origin == null) return new List<PersonVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
