using System;
using AOP.NET.Domain.Interfaces.Repositories;

namespace AOP.NET.Aspects
{
    public class RepositoryFactory
    {
        public static IRepository<T> Create<T>(IRepository<T> repo)
            => DynamicProxy<IRepository<T>>.Create(
                repo,
                (sender, info) => Console.WriteLine($"Before operation {info.Name}"),
                (sender, info) => Console.WriteLine("After operation"),
                (sender, info) => Console.WriteLine("Error"));
    }
}
