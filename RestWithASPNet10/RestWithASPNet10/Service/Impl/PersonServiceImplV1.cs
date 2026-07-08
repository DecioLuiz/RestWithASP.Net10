using Mapster;
using RestWithASPNet10.Data.Converter.Impl;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Service.Impl
{
    public class PersonServiceImplV1 : IPersonService
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImplV1(IRepository<Person> personRepository)
        {
            _repository = personRepository;
            _converter = new PersonConverter();
        }
        public List<PersonDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<PersonDTO>>();
        }
        public PersonDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<PersonDTO>();
        }
        public PersonDTO Create(PersonDTO personDTO)
        {
            var entity = personDTO.Adapt<Person>();
            entity = _repository.Create(entity);
            return entity.Adapt<PersonDTO>();
        }
        public PersonDTO Update(PersonDTO personDTO)
        {
            var entity = personDTO.Adapt<Person>();
            entity = _repository.Update(entity);
            return entity.Adapt<PersonDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
                
       