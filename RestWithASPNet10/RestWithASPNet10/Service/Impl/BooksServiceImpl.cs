using Mapster;
using RestWithASPNet10.Data.DTO;
using RestWithASPNet10.Model;
using RestWithASPNet10.Repositories;

namespace RestWithASPNet10.Service.Impl
{
    public class BooksServiceImpl : IBooksService
    {
        private IRepository<Books> _repository;

        public BooksServiceImpl(IRepository<Books> booksRepository)
        {
            _repository = booksRepository;
        }
        public List<BooksDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BooksDTO>>();
        }
        public BooksDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BooksDTO>();
        }
        public BooksDTO Create(BooksDTO book)
        {
            var entity = book.Adapt<Books>();
            entity = _repository.Create(entity);
            return entity.Adapt<BooksDTO>();
        }
        public BooksDTO Update(BooksDTO book)
        {
            var entity = book.Adapt<Books>();
            entity = _repository.Update(entity);
            return entity.Adapt<BooksDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
                
       