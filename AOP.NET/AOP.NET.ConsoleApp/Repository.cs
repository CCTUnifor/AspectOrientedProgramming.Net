using System;

namespace AOP.NET.ConsoleApp
{
    public class Repository<T> : IRepository<T>
    {
        public void Add(T entity)
        {
            Console.WriteLine("Adding the entity");
        }
    }

    public class RepositoryFactory
    {
        public static IRepository<T> Create<T>() => DynamicProxy<IRepository<T>>.Create(
            new Repository<T>(),
            (sender, info) => Console.WriteLine("Before operation"),
            (sender, info) => Console.WriteLine("After operation"),
            (sender, info) => Console.WriteLine("Error"));
    }
}