using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Service.Impl
{
    public class PersonServiceImpl : IPersonService
    {
        private IRepository<Person> _repository;

        public PersonServiceImpl(IRepository<Person> personRepository)
        {
            _repository = personRepository;
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
                
       