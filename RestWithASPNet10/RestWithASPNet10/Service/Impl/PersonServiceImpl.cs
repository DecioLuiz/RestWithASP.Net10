using RestWithASPNet10.Data.Converter.Impl;
using RestWithASPNet10.Data.DTO;
using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Service.Impl
{
    public class PersonServiceImpl : IPersonService
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImpl(IRepository<Person> personRepository)
        {
            _repository = personRepository;
            _converter = new PersonConverter();
        }
        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }
        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public PersonDTO Create(PersonDTO personDTO)
        {
            var entity = _converter.Parse(personDTO);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }
        public PersonDTO Update(PersonDTO personDTO)
        {
            var entity = _converter.Parse(personDTO);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
                
       