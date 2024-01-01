using System.Diagnostics;
using Application.Interfaces.Food;
using Application.Interfaces.Package;
using Application.Interfaces.ThirdParty;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class ProjectController : Controller
{
    private readonly IDonorService _donorService;
    private readonly IFoodService _foodService;
    private readonly IPackageReceivedService _packageReceivedService;
    private readonly IPackageSentService _packageSentService;
    private readonly IReceiverService _receiverService;

    public ProjectController(
        IDonorService donorService, IReceiverService receiverService,
        IFoodService foodService, IPackageReceivedService packageReceivedService,
        IPackageSentService packageSentService)
    {
        _donorService = donorService;
        _receiverService = receiverService;
        _foodService = foodService;
        _packageReceivedService = packageReceivedService;
        _packageSentService = packageSentService;
    }

    [HttpGet("/projectentities")]
    public IActionResult ProjectEntities()
    {
        var viewModel = new ProjectEntitiesViewModel
        {
            Donors = _donorService.GetAll(),
            Receivers = _receiverService.GetAll(),
            Foods = _foodService.GetAll()
        };

        return View(viewModel);
    }

    [HttpGet("/projectpackages")]
    public IActionResult ProjectPackages()
    {
        var viewModel = new ProjectPackagesViewModel
        {
            Donors = _donorService.GetAll(),
            Receivers = _receiverService.GetAll(),
            Foods = _foodService.GetAll(),
            PackagesReceived = _packageReceivedService.GetAll(),
            PackagesSent = _packageSentService.GetAll()
        };

        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}