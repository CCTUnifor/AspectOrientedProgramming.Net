using System;
using AOP.NET.Aspects;
using AOP.NET.Data.Repositories;
using AOP.NET.Domain.Entities;
using AOP.NET.Domain.Interfaces.Repositories;
using Ninject;

namespace AOP.NET.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IRepository<Customer>>().ToMethod((x) => RepositoryFactory.Create(new Repository<Customer>())).InTransientScope();

            var repo = kernel.Get<IRepository<Customer>>();
            var customer = new Customer();

            repo.Add(customer);
            Console.ReadLine();
        }
    }
}
