using GenericsApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericsApp.Repositories
{

    public delegate void ItemAdded<T> (T item);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;
        private readonly ItemAdded<T>? _itemAddedCallBack;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext, ItemAdded<T>? itemAdded = null)
        {
            _dbContext = dbContext;
            _itemAddedCallBack = itemAdded;
            _dbSet = _dbContext.Set<T>();
        }
        public T GetById(int id) => _dbSet.Find(id);

        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallBack?.Invoke(item);
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Remove(T item) => _dbSet.Remove(item);

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(t => t.Id).ToList();
        }
    }

    //public class GenericRepositoryWithRemove<T, TKey> : GenericRepository<T, TKey> 
    //{
    //    public void Remove(T item) => _items.Remove(item);
    //}

}
