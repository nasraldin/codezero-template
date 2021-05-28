using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeZero.Data.Repositories;
using CodeZeroTemplate.Entities;

namespace CodeZeroTemplate.Core.Repositries
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