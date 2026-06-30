using RestWithASPNet10.Model;

namespace RestWithASPNet10.Service
{
    public interface IBooksService
    {
        Books Create(Books book);
        Books FindById(long id);
        List<Books> FindAll();
        Books Update(Books book);
        void Delete(long id);
    }
}
