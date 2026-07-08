using RestWithASPNet10.Data.Converter.Contract;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Model;

namespace RestWithASPNet10.Data.Converter.Impl
{
    public class PersonConverter : IParser<Person, PersonDTO>, IParser<PersonDTO, Person>
    {
        public Person Parse(PersonDTO origin)
        {
            if(origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Gender = origin.Gender,
                Address = origin.Address,
              //  BirthDate = origin.BirthDate
            };
        }

        public PersonDTO Parse(Person origin)
        {
            if(origin == null) return null;
            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Gender = origin.Gender,
                Address = origin.Address,
                BirthDate = DateTime.Now
                //BirthDate = origin.BirthDate ?? DateTime.Now
            };
        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
