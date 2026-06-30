using RestWithASPNet10.Model;
using RestWithASPNet10.Model.Context;

namespace RestWithASPNet10.Repositories.Impl
{
    public class BooksRepository : IBooksRepository
    {
        private MSSQLContext _context;

        public BooksRepository(MSSQLContext context)
        {
            _context = context;
        }
        public List<Books> FindAll()
        {
            return _context.Books.ToList<Books>();
        }
        public Books FindById(long id)
        {
            return _context.Books.Find(id);
        }
        public Books Create(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public Books Update(Books book)
        {
            var bookToUpdate = _context.Books.Find(book.Id);
            if (bookToUpdate == null) return null;

            _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return book;
        }
        public void Delete(long id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
