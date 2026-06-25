using RestWithASPNet10.Model;
using RestWithASPNet10.Model.Context;

namespace RestWithASPNet10.Repositories.Impl
{
    public class PersonRepository : IPersonRepository
    {
        private MSSQLContext _context;

        public PersonRepository(MSSQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList<Person>();
        }
        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }
        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            var personToUpdate = _context.Persons.Find(person.Id);
            if (personToUpdate == null) return null;

            _context.Entry(personToUpdate).CurrentValues.SetValues(person);
            _context.SaveChanges();

            return person;
        }
        public void Delete(long id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
