using Application.Dtos.FoodDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models.FoodModels;

public class FoodUpdateViewModel
{
    public FoodResponseDto? Food { get; init; }
    public SelectList? StateOptions { get; init; }
}