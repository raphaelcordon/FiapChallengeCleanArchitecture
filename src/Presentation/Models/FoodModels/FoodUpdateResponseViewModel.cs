using Domain.Enums.Food;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models.FoodModels;

public class FoodUpdateResponseViewModel
{
    public Guid Id { get; set; }
    public string FoodName { get; set; }
    public State State { get; set; }
    public bool IsPerishable { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public SelectList StateOptions { get; set; }
}