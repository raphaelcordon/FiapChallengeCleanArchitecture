using Application.Dtos.PackageDtos;
using Application.Interfaces.Food;
using Application.Interfaces.Package;
using Application.Interfaces.ThirdParty;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.PackageReceivedModels;

namespace Presentation.Controllers;

public class PackageReceivedController : Controller
{
    private readonly IPackageReceivedService _packageReceived;
    private readonly IDonorService _donorService;
    private readonly IFoodService _foodService;

    public PackageReceivedController(IPackageReceivedService packageReceivedService, IDonorService donorService, IFoodService foodService)
    {
        _packageReceived = packageReceivedService;
        _donorService = donorService;
        _foodService = foodService;
    }

    [HttpGet("/PackageReceivedCreate")]
    public IActionResult PackageReceivedCreate()
    {
        var viewModel = new PackageReceivedViewModels
        {
            Donors = _donorService.GetAll(),
            Foods = _foodService.GetAll()
        };
        return View(viewModel);
    }
    
    [HttpGet("PackageReceivedUpdate/{id:guid}")]
    public async Task<IActionResult> PackageReceivedUpdate(Guid id)
    {
        var viewModel = new PackageReceivedUpdateViewModels
        {
            Package = await _packageReceived.GetById(id),
            Donors = _donorService.GetAll(),
            Foods = _foodService.GetAll()
        };

        return View(viewModel);
    }

    [HttpGet("PackageReceivedDelete/{id}")]
    public async Task<IActionResult> PackageReceivedDelete(Guid id)
    {
        await _packageReceived.Delete(id);

        return RedirectToAction("ProjectPackages", "Project");
    }
    

    [HttpPost("PackageReceivedNew")]
    public async Task<IActionResult> PackageReceivedNew(PackageReceivedResponseViewModels formViewModel)
    {
        var dto = new PackageReceivedRequestDto
        {
            FoodList = formViewModel.SelectedFoods,
            DonorId = formViewModel.DonorId
        };
        
        await _packageReceived.Insert(dto);
        
        TempData["ConfirmationMessage"] = "PackageReceived created successfully";
        return RedirectToAction("ProjectPackages", "Project");
    }
    
    [HttpPost("PackageReceivedUpdated")]
    public async Task<IActionResult> PackageReceivedUpdated(PackageReceivedResponseViewModels formViewModel)
    {
        var dto = new PackageReceivedRequestDto
        {
            FoodList = formViewModel.SelectedFoods,
            DonorId = formViewModel.DonorId
        };
        var id = formViewModel.Id;
        await _packageReceived.Edit(id, dto);

        TempData["ConfirmationMessage"] = "PackageReceived created successfully";

        return RedirectToAction("ProjectPackages", "Project");
    }
}