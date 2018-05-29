namespace AOP.NET.ConsoleApp
{
    public interface IRepository<T>
    {
        void Add(T entity);
    }
}