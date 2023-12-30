using Application.Dtos.FoodDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models;

public class FoodUpdateViewModel
{
    public FoodResponseDto Food { get; set; }
    public SelectList StateOptions { get; set; }
}