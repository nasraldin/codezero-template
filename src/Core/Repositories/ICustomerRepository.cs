using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeZero.Data.Repositories;
using Entities;

namespace Core.Domain.Repositries
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByEmail(string email);
        Task<IEnumerable<Customer>> GetAll();

        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}