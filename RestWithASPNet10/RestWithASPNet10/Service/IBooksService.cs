using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Model;

namespace RestWithASPNet10.Service
{
    public interface IBooksService
    {
        BooksDTO Create(BooksDTO book);
        BooksDTO FindById(long id);
        List<BooksDTO> FindAll();
        BooksDTO Update(BooksDTO book);
        void Delete(long id);
    }
}
