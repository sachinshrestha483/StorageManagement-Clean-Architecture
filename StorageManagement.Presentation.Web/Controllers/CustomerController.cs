using Microsoft.AspNetCore.Mvc;
using StorageManagement.Core.Application.Services.Abstractions;
using StorageManagement.Core.Application.Services.Implementations;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Core.Domain.ValueObjects;
using StorageManagement.Presentation.Web.Models.ViewModels;

namespace StorageManagement.Presentation.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var customers = _customerService.GetAll();

            return View(customers);
        }
        public IActionResult Create()
        {
            var viewModel = new UpsertCustomerViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(UpsertCustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var address = Address.Create(street: viewModel.AddressStreet, city: viewModel.AddressCity, pincode: viewModel.AddressPincode);
                var contactPerson = new ContactPerson(Name: viewModel.ContactPersonName, PhoneNumber: viewModel.ContactPersonPhone);

                var customer = new Customer(name: viewModel.Name, pan: viewModel.Pan, address: address, contactPerson: contactPerson);

                _customerService.Create(customer);
                _customerService.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetById(id);
            var viewModel = new UpsertCustomerViewModel()
            {
                Id = customer.Id.Value,
                Name = customer.Name,
                Pan = customer.Pan,
                AddressCity = customer.Address.City,
                AddressPincode = customer.Address.Pincode,
                AddressStreet = customer.Address.Street,
                ContactPersonName = customer.ContactPerson.Name,
                ContactPersonPhone = customer.ContactPerson.PhoneNumber
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(UpsertCustomerViewModel viewModel)
        {
            var customer = _customerService.GetById(viewModel.Id);

            if (customer == null)
            {
                return NotFound();
            }

            var address = Address.Create(street: viewModel.AddressStreet, city: viewModel.AddressCity, pincode: viewModel.AddressPincode);
            var contactPerson = new ContactPerson(Name: viewModel.ContactPersonName, PhoneNumber: viewModel.ContactPersonPhone);

            customer.Update(name: viewModel.Name, pan: viewModel.Pan, address: address, contactPerson: contactPerson);

            _customerService.Update(customer);
            _customerService.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
