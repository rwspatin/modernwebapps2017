using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
        }

        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            Email = email;
            Document = document;
            User = user;
        }

        public Customer(Name name, DateTime? birthDate, Email email, User user, Document document)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            User = user;
            Document = document;

            AddNotifications(email.Notifications);
            AddNotifications(name.Notifications);
        }

        public Document Document { get; private set; }
        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Email Email { get; private set; }
        public User User { get; private set; }

        public override string ToString() => $"{Name.FirstName} {Name.LastName}";
    }
}
