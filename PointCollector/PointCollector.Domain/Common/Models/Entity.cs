using MediatR;
using PointCollector.Domain.Common.Exceptions;
using PointCollector.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCollector.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
    {
        public TId Id { get; protected set; }
        
        protected Entity()
        {

        }
        protected Entity(TId id)
        {
            Id = id;
        }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        protected static void CheckRule(IBusinessRule rule)
        {
            if(rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
