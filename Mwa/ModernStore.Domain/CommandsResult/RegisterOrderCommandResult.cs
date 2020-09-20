using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandsResult
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult()
        {
        }

        public RegisterOrderCommandResult(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
