using RestWithASPNet10.Data.Converter.Impl;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Service.Impl
{
    public class PersonServiceImplV2
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImplV2(IRepository<Person> personRepository)
        {
            _repository = personRepository;
            _converter = new PersonConverter();
        }
 
        public PersonDTO Create(PersonDTO personDTO)
        {
            var entity = _converter.Parse(personDTO);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }
    }
}
                
       