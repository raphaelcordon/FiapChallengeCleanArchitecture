using Application.Dtos.PackageDtos;
using Application.Interfaces.Food;
using Application.Interfaces.Package;
using Application.Interfaces.ThirdParty;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.PackageSentModels;

namespace Presentation.Controllers;

public class PackageSentController : Controller
{
    private readonly IPackageSentService _packageSent;
    private readonly IReceiverService _receiverService;
    private readonly IFoodService _foodService;

    public PackageSentController(IPackageSentService packageSentService, IReceiverService receiverService, IFoodService foodService)
    {
        _packageSent = packageSentService;
        _receiverService = receiverService;
        _foodService = foodService;
    }

    [HttpGet("/PackageSentCreate")]
    public IActionResult PackageSentCreate()
    {
        var viewModel = new PackageSentViewModels
        {
            Receivers = _receiverService.GetAll(),
            Foods = _foodService.GetAll()
        };
        return View(viewModel);
    }
    
    [HttpGet("PackageSentUpdate/{id:guid}")]
    public async Task<IActionResult> PackageSentUpdate(Guid id)
    {
        var viewModel = new PackageSentUpdateViewModels
        {
            Package = await _packageSent.GetById(id),
            Receivers = _receiverService.GetAll(),
            Foods = _foodService.GetAll()
        };

        return View(viewModel);
    }

    [HttpGet("PackageSentDelete/{id}")]
    public async Task<IActionResult> PackageSentDelete(Guid id)
    {
        await _packageSent.Delete(id);

        return RedirectToAction("ProjectPackages", "Project");
    }
    

    [HttpPost("PackageSentNew")]
    public async Task<IActionResult> PackageSentNew(PackageSentResponseViewModels formViewModel)
    {
        var dto = new PackageSentRequestDto
        {
            FoodList = formViewModel.SelectedFoods,
            ReceiverId = formViewModel.ReceiverId
        };
        
        await _packageSent.Insert(dto);
        
        TempData["ConfirmationMessage"] = "PackageSent created successfully";
        return RedirectToAction("ProjectPackages", "Project");
    }
    
    [HttpPost("PackageSentUpdated")]
    public async Task<IActionResult> PackageSentUpdated(PackageSentResponseViewModels formViewModel)
    {
        var dto = new PackageSentRequestDto
        {
            FoodList = formViewModel.SelectedFoods,
            ReceiverId = formViewModel.ReceiverId
        };
        var id = formViewModel.Id;
        await _packageSent.Edit(id, dto);

        TempData["ConfirmationMessage"] = "PackageSent created successfully";

        return RedirectToAction("ProjectPackages", "Project");
    }
}