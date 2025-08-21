using DemoDayCQRSProject.Context;
using DemoDayCQRSProject.CQRS.Commands.CategoryCommands;
using DemoDayCQRSProject.CQRS.Commands.CustomerCommands;

namespace DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommandHandler
    {
        private readonly DemoContext _context;

        public RemoveCustomerCommandHandler(DemoContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCustomerCommand command)
        {
            var values = await _context.Customers.FindAsync(command.CustomerId);
            _context.Customers.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
