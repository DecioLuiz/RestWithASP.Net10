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
        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }
        public Books FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Books Create(Books book)
        {
            return _repository.Create(book);
        }
        public Books Update(Books book)
        {
            return _repository.Update(book);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
                
       