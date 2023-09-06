namespace DoctorApp.Interfaces
{
    public interface IRepository<K,T>where T : class
    {
        public T Add(T entity);
        public T Delete(K id);
        public T GetById(K id);

        public T Update(T entity);

      
        public ICollection<T> GetAll();

    }
}
