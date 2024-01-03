using Application.Dtos.ThirdPartyDtos;
using Application.Interfaces.ThirdParty;
using Domain.Entities.ThirdPartyRegister;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.DonorModels;

namespace Presentation.Controllers;

public class DonorController : Controller
{
    private readonly IDonorService _donorService;

    public DonorController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    [HttpGet("/DonorCreate")]
    public IActionResult DonorCreate()
    {
        return View();
    }

    [HttpGet("DonorUpdate/{id:guid}")]
    public async Task<IActionResult> DonorUpdate(Guid id)
    {
        var viewModel = await _donorService.GetById(id);

        return View(viewModel);
    }

    [HttpGet("DonorDelete/{id:guid}")]
    public async Task<IActionResult> DonorDelete(Guid id)
    {
        await _donorService.Delete(id);

        return RedirectToAction("ProjectEntities", "Project");
    }


    [HttpPost("DonorNew")]
    public async Task<IActionResult> DonorNew(DonorFormViewModel formViewModel)
    {
        var dto = new DonorRequestDto
        {
            Name = new ThirdPartyName(formViewModel.Name!),
            IsCompany = formViewModel.IsCompany
        };

        await _donorService.Insert(dto);

        TempData["ConfirmationMessage"] = "Donor created successfully";

        return RedirectToAction("ProjectEntities", "Project");
    }

    [HttpPost("DonorUpdated")]
    public async Task<IActionResult> DonorUpdated(DonorFormViewModel formViewModel)
    {
        var dto = new DonorRequestDto
        {
            Name = new ThirdPartyName(formViewModel.Name!),
            IsCompany = formViewModel.IsCompany
        };
        var id = formViewModel.Id;
        await _donorService.Edit(id, dto);

        TempData["ConfirmationMessage"] = "Donor created successfully";
        return RedirectToAction("ProjectEntities", "Project");
    }
}