using System;

namespace AOP.NET.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var repo = RepositoryFactory.Create<Customer>();
            var customer = new Customer();

            repo.Add(customer);
            Console.ReadLine();
        }
    }
}
