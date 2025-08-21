using DemoDayCQRSProject.CQRS.Commands.CustomerCommands;
using DemoDayCQRSProject.CQRS.Handlers.CustomerHandlers;
using DemoDayCQRSProject.CQRS.Queries.CustomerQueries;
using Microsoft.AspNetCore.Mvc;

namespace DemoDayCQRSProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly GetCustomerQueryHandler _getCustomerQueryHandler;
        private readonly GetCustomerByIdQueryHandler _getCustomerByIdQueryHandler;
        private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
        private readonly UpdateCustomerCommandHandler _updateCustomerCommandHandler;
        private readonly RemoveCustomerCommandHandler _removeCustomerCommandHandler;

        public CustomerController(GetCustomerQueryHandler getCustomerQueryHandler, GetCustomerByIdQueryHandler getCustomerByIdQueryHandler, CreateCustomerCommandHandler createCustomerCommandHandler, UpdateCustomerCommandHandler updateCustomerCommandHandler, RemoveCustomerCommandHandler removeCustomerCommandHandler)
        {
            _getCustomerQueryHandler = getCustomerQueryHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            _createCustomerCommandHandler = createCustomerCommandHandler;
            _updateCustomerCommandHandler = updateCustomerCommandHandler;
            _removeCustomerCommandHandler = removeCustomerCommandHandler;
        }

        public async Task<IActionResult> CustomerList()
        {
            var values = await _getCustomerQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            await _createCustomerCommandHandler.Handle(command);
            return RedirectToAction("CustomerList");
        }
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            await _removeCustomerCommandHandler.Handle(new RemoveCustomerCommand(id));
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var value = await _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            await _updateCustomerCommandHandler.Handle(command);
            return RedirectToAction("CustomerList");
        }
    }
}
