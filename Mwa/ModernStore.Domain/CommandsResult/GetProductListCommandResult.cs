using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.CommandsResult
{
    public class GetProductListCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
