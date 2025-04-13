using DataLayer;


namespace ServiceLayer
{
    public class LibraryManager<T, K>
    {
        private IDb<T, K> context;

        public LibraryManager(IDb<T, K> context)
        {
            this.context = context;
        }

        public void Create(T item)
        {
            context.Create(item);
        }

        public T Read(K key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Read(key);
        }
        public List<T> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.ReadAll();
        }

        public void Update(T item, bool useNavigationalProperties = false)
        {
            context.Update(item);
        }

        public void Delete(K key)
        {
            context.Delete(key);
        }





    }
}
