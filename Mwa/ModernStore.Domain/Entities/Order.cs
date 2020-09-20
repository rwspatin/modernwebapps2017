using FluentValidator.Validation;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        public Order()
        {

        }
        private readonly IList<OrderItem> _items;
        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8);
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            DeliveryFee = deliveryFee;
            Discount = discount;

            AddNotifications(new ValidationContract()
                                .Requires()
                                .IsGreaterThan(DeliveryFee, 0, "DeliveryFee", "A DeliveryFee é inválida")
                                .IsGreaterThan(DeliveryFee, -1, "DeliveryFee", "A DeliveryFee é inválida")
                                );
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items => _items.ToArray();
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }
        
        public decimal SubTotal() => Items.Sum(x => x.Total());
        
        public decimal Total() => SubTotal() + DeliveryFee - Discount;
        
        public void AddItem(OrderItem item)
        {
            if (item.Valid)
                _items.Add(item);
        }
    }
}
