using FluentValidator.Validation;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem()
        {

        }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            AddNotifications(new ValidationContract()
                                .Requires()
                                .IsGreaterThan(Quantity, 1, "Quantity", "A Quantidade é inválida")
                                .IsGreaterThan(Product.QuantityOnHand, Quantity + 1, "Quantity", "A Quantidade é inválida")
                                );

            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}