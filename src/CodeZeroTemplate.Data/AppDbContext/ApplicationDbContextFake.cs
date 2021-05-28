using System.Collections.ObjectModel;
using CodeZeroTemplate.Data.SeedData;
using CodeZeroTemplate.Entities;

namespace CodeZeroTemplate.Data.AppDbContext
{
    public class ApplicationDbContextFake
    {
        public ApplicationDbContextFake()
        {
            var customer = new Customer(CustomerSeed.Name, CustomerSeed.Email, CustomerSeed.BirthDate);

            this.Customers.Add(customer);
        }

        public Collection<Customer> Customers { get; } = new Collection<Customer>();
        public Collection<Log> Logs { get; } = new Collection<Log>();
    }
}