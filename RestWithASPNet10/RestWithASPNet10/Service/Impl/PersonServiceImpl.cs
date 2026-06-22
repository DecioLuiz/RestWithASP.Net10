using RestWithASPNet10.Model;

namespace RestWithASPNet10.Service.Impl
{
    public class PersonServiceImpl : IPersonService
    {
        public List<Person> FindAll()
        {
            List<Person> list = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                var person = MockPerson(i);
                list.Add(person);
            }
            return list;
        }
        public Person FindById(long id)
        {
            var person = MockPerson((int)id);
            return person;
        }
        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000);
            return person;
        }
        public Person Update(Person person)
        {
            return person;
        }
        public void Delete(long id)
        {
            // No content
        }
        private Person MockPerson(int i)
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "Leandro " + i,
                LastName = "Costa " + i,
                Address = "Uberlândia - Minas Gerais - Brasil " + i,
                Gender = "Male"
            };
            return person;
        }
    }
}
   
