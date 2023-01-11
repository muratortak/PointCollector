using MediatR;
using PointCollector.Domain.Common.Interfaces;
using PointCollector.Domain.Common.Models;
using PointCollector.Domain.Entities.Customers.Events;
using PointCollector.Domain.Entities.Customers.Exceptions;
using PointCollector.Domain.Entities.Customers.Rules;
using PointCollector.Domain.Entities.Customers.ValueObjects;

namespace PointCollector.Domain.Entities.Customers
{
    public class Customer : Entity<Guid>, IAggregateRoot
    {
        public Customer()
        {
            // required by EF
        }

        private Customer(string firstName, string lastName, string email, string password) : base(Guid.NewGuid())
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static Customer Create(string firstName, string lastName, string email, string password, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email), typeof(CustomerEmailMustBeUniqueException));
            var customer = new Customer(firstName, lastName, email, password);
            customer.AddDomainEvents(new List<INotification> { new UserRegisteredDomainEvent(customer.Id) });
            return customer;
        } 

        private void AddDomainEvents(List<INotification> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                AddDomainEvent(domainEvent);
            }
        }

        public Guid Id { get; private set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual ICollection<Point> Points { get; set; }

        public void AddPoint(Guid workspaceId, decimal point)
        {
            // check rule that point cannot be less than zero
            CheckRule(new PointMustBeGreaterThanEqualToZeroRule(point), typeof(PointMustBeGreaterThanEqualToZeroException));
            if (Points == null)
            {
                Points = new List<Point>();
            }
            Points.Add(new Point(workspaceId, point));
            AddDomainEvents(new List<INotification> { new UserCollectedPointsDomainEvent(Id) });
        }

        public decimal GetTotalPoint()
        {
            return Points.Sum(x => x.CollectedPoint);
        }

    }
}
