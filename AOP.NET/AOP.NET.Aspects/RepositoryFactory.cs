using System;
using AOP.NET.Domain.Interfaces.Repositories;

namespace AOP.NET.Aspects
{
    public class RepositoryFactory
    {
        public static IRepository<T> Create<T>(IRepository<T> repo)
            => DynamicProxy<IRepository<T>>.Create(
                repo,
                before: (sender, info) => Console.WriteLine($"Before operation {info.Name}"),
                after: (sender, info) => Console.WriteLine("After operation"),
                error: (sender, info) => Console.WriteLine("Error"));
    }
}
