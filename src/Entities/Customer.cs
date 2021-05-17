using System;
using CodeZero.Domain;
using CodeZero.Domain.Entities;

namespace Entities
{
    public class Customer : BaseEntity<int>, IAggregateRoot
    {
        public Customer(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        protected sealed override bool Validate() => false;
    }
}