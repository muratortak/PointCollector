using PointCollector.Domain.Common.Interfaces;
using PointCollector.Domain.Common.Models;
using PointCollector.Domain.Entities.Customers.Rules;
using PointCollector.Domain.Entities.Customers.ValueObjects;

namespace PointCollector.Domain.Entities.Customers
{
    public class Customer : Entity<CustomerId>, IAggregateRoot
    {
        private Customer()
        {
            // required by EF
        }

        private Customer(string firstName, string lastName, string email, string password) : base(CustomerId.Create())
        {
            Id = base.Id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static Customer Create(string firstName, string lastName, string email, string password, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));

            return new Customer(firstName, lastName, email, password);
        } 

        public CustomerId Id { get; private set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        private void CustomerExistsException()
        {
            throw new CustomerException($"Username exists");
        }
    }
}
