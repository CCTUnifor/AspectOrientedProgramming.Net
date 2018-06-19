namespace AOP.NET.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
    }
}