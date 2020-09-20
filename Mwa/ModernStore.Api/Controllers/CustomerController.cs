using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.CommandHandler;
using ModernStore.Domain.Commands;
using ModernStore.Infra.Transactions;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUow uow, CustomerCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}