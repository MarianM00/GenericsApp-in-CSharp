using GenericsApp.Entities;

namespace GenericsApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly List<T> _items = new();


        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item) 
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }


        public void Save()
        {
            //
        }

        public void Remove(T item) => _items.Remove(item);

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
    }

    //public class GenericRepositoryWithRemove<T, TKey> : GenericRepository<T, TKey> 
    //{
    //    public void Remove(T item) => _items.Remove(item);
    //}

}
