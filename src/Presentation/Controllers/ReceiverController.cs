using Application.Dtos.ThirdPartyDtos;
using Application.Interfaces.ThirdParty;
using Domain.Entities.ThirdPartyRegister;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class ReceiverController : Controller
{
    private readonly IReceiverService _receiverService;

    public ReceiverController(IReceiverService receiverService)
    {
        _receiverService = receiverService;
    }

    [HttpGet("/ReceiverCreate")]
    public IActionResult ReceiverCreate()
    {
        return View();
    }

    [HttpGet("ReceiverUpdate/{id}")]
    public async Task<IActionResult> ReceiverUpdate(Guid id)
    {
        var viewModel = await _receiverService.GetById(id);

        return View(viewModel);
    }

    [HttpGet("ReceiverDelete/{id}")]
    public async Task<IActionResult> ReceiverDelete(Guid id)
    {
        await _receiverService.Delete(id);

        return RedirectToAction("ProjectEntities", "Project");
    }


    [HttpPost("ReceiverNew")]
    public async Task<IActionResult> ReceiverNew(ReceiverFormViewModel formViewModel)
    {
        var dto = new ReceiverRequestDto
        {
            Name = new ThirdPartyName(formViewModel.Name),
            IsCompany = formViewModel.IsCompany
        };

        var createdReceiver = await _receiverService.Insert(dto);

        TempData["ConfirmationMessage"] = "Receiver created successfully";

        return RedirectToAction("ProjectEntities", "Project");
    }

    [HttpPost("ReceiverUpdated")]
    public async Task<IActionResult> ReceiverUpdated(ReceiverFormViewModel formViewModel)
    {
        var dto = new ReceiverRequestDto
        {
            Name = new ThirdPartyName(formViewModel.Name),
            IsCompany = formViewModel.IsCompany
        };
        var id = formViewModel.Id;
        var createdReceiver = await _receiverService.Edit(id, dto);

        TempData["ConfirmationMessage"] = "Receiver created successfully";
        return RedirectToAction("ProjectEntities", "Project");
    }
}