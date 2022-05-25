namespace forum_api.Repositories
{
    public interface GenericRepository<T>
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public T Create(T entity);
        public T Update(T entity);
        public T Delete(T entity);
    }
}
