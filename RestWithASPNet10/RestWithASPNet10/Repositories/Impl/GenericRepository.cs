using Microsoft.EntityFrameworkCore;
using RestWithASPNet10.Model.Base;
using RestWithASPNet10.Model.Context;

namespace RestWithASPNet10.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MSSQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.Find(id);
        }
        public T Create(T item)
        {
            dataset.Add(item);
            _context.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            var result = dataset.Find(item.Id);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            return result;
        
        }
        public void Delete(long id)
        {
            var result = dataset.Find(id);
            if (result != null)
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(e => e.Id == id);
        }
    }
}
