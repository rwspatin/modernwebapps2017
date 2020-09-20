using FluentValidator;
using FluentValidator.Validation;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email()
        {

        }
        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new ValidationContract()
                                .Requires()
                                .IsEmail(Address, "Email", "O E-Mail é inválido")
                                );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }


    }
}
