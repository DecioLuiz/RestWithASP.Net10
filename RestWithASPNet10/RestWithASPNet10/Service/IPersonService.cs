using RestWithASPNet10.Data.DTO;

namespace RestWithASPNet10.Service
{
    public interface IPersonService
    {
        PersonDTO Create(PersonDTO personDTO);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO personDTO);
        void Delete(long id);
    }
}
