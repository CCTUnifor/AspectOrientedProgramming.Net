using System;
using AOP.NET.Domain.Interfaces.Repositories;

namespace AOP.NET.Data.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            Console.WriteLine("new Repository instance");
        }
        public void Add(T entity)
        {
            Console.WriteLine("Adding the entity");
        }
    }
}