using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorageManagement.Core.Application.Services.Abstractions;
using StorageManagement.Core.Application.Services.Implementations;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Presentation.Web.Models.ViewModels;
using System.Net.WebSockets;

namespace StorageManagement.Presentation.Web.Controllers
{
    [Authorize]
    public class GateEntryController : Controller
    {
        private readonly IGateEntryService _gateEntryService;

        public GateEntryController(IGateEntryService gateEntryService)
        {
            _gateEntryService = gateEntryService;
        }

        public IActionResult Index()
        {
            var gateEntries = _gateEntryService.GetAll();
        
            return View(gateEntries);
        }

        public IActionResult Create()
        {
            var viewModel = new UpsertGateEntryViewModel()
            {
                CheckIn = DateTimeOffset.Now,
                CheckOut = DateTimeOffset.Now,
                EntryReference = string.Empty,
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(UpsertGateEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _gateEntryService.Create(new GateEntry(entryReference: viewModel.EntryReference, entryType: viewModel.EntryType,
                                                        checkIn: viewModel.CheckIn, checkOut: viewModel.CheckOut), User.Identity.Name
                );

                _gateEntryService.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var gateEntry = _gateEntryService.GetById(id);
            
            if(gateEntry is null)
            {
                return NotFound();
            }

            var viewModel = new UpsertGateEntryViewModel()
            {
                CheckIn = gateEntry.CheckIn,
                CheckOut = gateEntry.CheckOut,
                EntryReference = gateEntry.EntryReference,
                EntryType = gateEntry.EntryType,
                Id = id
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(UpsertGateEntryViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var gateEntry = _gateEntryService.GetById(viewModel.Id);

                if(gateEntry==null)
                {
                    return RedirectToAction(nameof(Index));
                }

                gateEntry.Update(entryReference:viewModel.EntryReference,checkIn:viewModel.CheckIn,checkOut:viewModel.CheckOut,entryType:viewModel.EntryType);

                _gateEntryService.Update(gateEntry,User.Identity.Name);
                _gateEntryService.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
