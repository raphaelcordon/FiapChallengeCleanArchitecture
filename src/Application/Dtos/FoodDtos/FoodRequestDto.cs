using System.ComponentModel.DataAnnotations;
using Application.Common;
using Domain.Entities.Food;
using Domain.Enums.Food;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Dtos.FoodDtos;

public class FoodRequestDto
{
    public FoodName FoodName { get; set; }
    public State State { get; set; }
    public bool IsPerishable { get; set; }

    [DateAfterToday(ErrorMessage = "The date must be a future date.")]
    public DateOnly ExpirationDate { get; set; }
}