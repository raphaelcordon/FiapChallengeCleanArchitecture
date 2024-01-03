using Application.Dtos.FoodDtos;
using Application.Interfaces.Food;
using Domain.Entities.Food;
using Domain.Enums.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using Presentation.Models.FoodModels;

namespace Presentation.Controllers;

public class FoodController : Controller
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpGet("/FoodCreate")]
    public IActionResult FoodCreate()
    {
        var stateViewModel = new StateViewModel
        {
            States = Enum.GetValues(typeof(State))
                .Cast<State>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = ((int)s).ToString()
                })
                .ToList()
        };
        return View(stateViewModel);
    }

    [HttpGet("FoodUpdate/{id:guid}")]
    public async Task<IActionResult> FoodUpdate(Guid id)
    {
        var foodDto = await _foodService.GetById(id);
        var stateOptions = Enum.GetValues(typeof(State))
            .Cast<State>()
            .Select(s => new SelectListItem
            {
                Text = s.ToString(),
                Value = ((int)s).ToString(),
                Selected = s == foodDto.State
            });

        var viewModel = new FoodUpdateViewModel
        {
            Food = foodDto,
            StateOptions = new SelectList(stateOptions, "Value", "Text")
        };

        return View(viewModel);
    }

    [HttpGet("FoodDelete/{id:guid}")]
    public async Task<IActionResult> FoodDelete(Guid id)
    {
        await _foodService.Delete(id);

        return RedirectToAction("ProjectEntities", "Project");
    }


    [HttpPost("FoodNew")]
    public async Task<IActionResult> FoodNew(FoodUpdateResponseViewModel updateResponseViewModel)
    {
        var dto = new FoodRequestDto
        {
            FoodName = new FoodName(updateResponseViewModel.FoodName!),
            State = updateResponseViewModel.State,
            IsPerishable = updateResponseViewModel.IsPerishable,
            ExpirationDate = updateResponseViewModel.ExpirationDate
        };

        await _foodService.Insert(dto);

        TempData["ConfirmationMessage"] = "Food created successfully";

        return RedirectToAction("ProjectEntities", "Project");
    }

    [HttpPost("FoodUpdated")]
    public async Task<IActionResult> FoodUpdated(FoodUpdateResponseViewModel formViewModel)
    {
        var dto = new FoodRequestDto
        {
            FoodName = new FoodName(formViewModel.FoodName!),
            State = formViewModel.State,
            IsPerishable = formViewModel.IsPerishable,
            ExpirationDate = formViewModel.ExpirationDate
        };
        var id = formViewModel.Id;
        await _foodService.Edit(id, dto);

        TempData["ConfirmationMessage"] = "Food created successfully";
        return RedirectToAction("ProjectEntities", "Project");
    }
}